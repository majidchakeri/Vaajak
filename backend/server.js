const bodyParser = require('body-parser');
const express = require('express');
const dotenv = require('dotenv');

dotenv.config({path : './config/config.env'});
const databaseConnect = require('./model/usersModel');

/* Routes */
const usersRouter = require('./routes/usersRoutes');
const  contentRouter = require("./routes/contentRoutes")
//create database
const app = express();


app.use(bodyParser.json());
app.use(
    bodyParser.urlencoded({
        extended: true,
    })
);
app.get('/', (req, res, next) => {
    res.json({'message': 'ok'});
});
app.use('/api/v1/user', usersRouter);
app.use('/api/v1/content', contentRouter);

databaseConnect.sync()
    .then((result) => {
        const port = process.env.PORT;
        app.listen(3000, () => console.log(`Server Is Running ${port}`));
    })
    .catch((err) => {
        console.log(err);
    })
