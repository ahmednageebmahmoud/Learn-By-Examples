const { MongoClient, ObjectId } = require('mongodb');

/** @type {MongoClient} */
var client = null;



/** Connect To DB */
module.exports.connect = async () => {
    client = new MongoClient(process.env.MONGO_URL);
    // Use connect method to connect to the server
    await client.connect();
    console.log(':) Connected successfully to server');
}

/** Employee Operations */
class Employee {
    get emp() {
        return client.db(process.env.MONGO_DB_NAME).collection('employees');
    }
    create(name, age) {
        console.log('Create Employee Started...');
        return this.emp.insertOne({ name, age })
    }
    edit(id, name, age) {
        console.log('Update Employee Started...');
        return this.emp.updateOne({ _id: new ObjectId(id) }, { $set: { name, age } })
    }
    delete(id) {
        console.log('Delete Employee Started...');
        return this.emp.deleteOne({ _id:new ObjectId(id) })
    }
    getById(id) {
        console.log('Get Employee Started...');
        return this.emp.findOne({ _id:new ObjectId(id) })
    }
    getList() {
        console.log('Get List Employees Started...');
        return this.emp.find()
    }
}

module.exports.employee = new Employee();