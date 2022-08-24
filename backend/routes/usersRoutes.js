const router = require('express').Router();

const usersController= require('../controllers/usersController');
const authController= require('../controllers/authController');
console.log('user router is runing ++++++++++++++++');
router.post('/signup',authController.signup);
router.post('/login',authController.login);

router.route('/users',)
    .post(usersController.createUser) //run createUser from controller
    .get(usersController.getAllUser); //run getAllUser from controller

// router.route('/ussers/:username')
//     .get((req,res,next) => {
//         const id = req.params.userId;
//         if(id && usersData[id]) {
//             res.json(usersData[id]);
//             res.status(200).send();
//         } else  {
//             // Not Found
//             res.status(404).send();
//         }
//     })

module.exports= router;