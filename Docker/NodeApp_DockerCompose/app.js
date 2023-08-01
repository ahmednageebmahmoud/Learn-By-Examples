const express = require('express');
const dotenv = require('dotenv');
const db = require('./initDB')
var bodyParser = require('body-parser')

//loads environment variables from a .env file into process.env
dotenv.config();

//Connect To DB
db.connect();

//Create Express APP
const app = express();

// parse application/x-www-form-urlencoded
app.use(bodyParser.urlencoded({ extended: false }))

// parse application/json
app.use(bodyParser.json())


//Start APP
app.listen(process.env.PORT, () => { console.log(`:) App Is Started On http://localhost:${process.env.PORT}`); });


//Create Index Router
app.get('/', (req, res) => {
    res.write('<h1>Hellow Test Nodemone 231</h1>');
    res.end();
})



//Create Employee 
app.post('/employee', async (req, res) => { res.json(await db.employee.create(req.body.name, req.body.age)) })

//Update Employee 
app.put('/employee', async (req, res) => { res.json(await db.employee.edit(req.body.id, req.body.name, req.body.age)) })

//Delete Employee 
app.delete('/employee', async (req, res) => { res.json(await db.employee.delete(req.body.id)) })

//Get By Id Employee 
app.get('/employee/:id', async (req, res) => { res.json(await db.employee.getById(req.params.id)) })

//Employees List 
app.get('/employee', async (req, res) => { res.json(await db.employee.getList().toArray()); })


