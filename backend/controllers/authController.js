const jwt = require('jsonwebtoken')

const catchAsync = require('../utils/catchAsync');
const usersModel = require('../model/usersModel');
const { userSchema } = require('../model/secure/userValidation');
const AppError = require('../utils/appError');

const signToken = id => {
    return jwt.sign({ id }, process.env.JWT_SECRET, {expiresIn: process.env.JWT_EXPIRES_IN});
}
exports.signup = async (req, res, next) => {
    try {
        const reqBody = req.body;
        await userSchema.validate(reqBody)
        .then(async (result) => {
                console.log('ok ok ok', result);
                const { name, email, username, password, passwordConfirm } = req.body;
                console.log(name, email, username, password, passwordConfirm);
                const newUser = await usersModel.create({ name: name, email: email, username: username, password: password, passwordConfirm: passwordConfirm, status:1 })
                const token = signToken(newUser.id);
                res.status(201).json({ 
                    status : "success",
                    token,
                    data : {
                        message : "user created.",
                        user : newUser
                    }
                });


            // }
        })
        .catch((err) => {
            console.log(err);
            next(err);
        })        
    } catch (error) {
        // const error = new Error("This email already exist.");
        console.log(error);
        error.statusCode = 422;
        next(err);
    }

};

exports.login = async (req, res, next) => {
    const { email, password } = req.body;
    console.log('pasword',password);
    if (!email || !password) {
        return next(new AppError('Please provide email and password!', 400));
    }
    // const token = jwt.sign({id: newUser.id}, process.env.JWT_SECRET, {expiresIn: process.env.JWT_EXPIRES_IN})
    const user = await usersModel.scope('withPassword').findOne({where: {email }});
    console.log(user.password);
    
    if (!user || !(await user.comparePassword(password, user.password))) {
        return next(new AppError('incorrect email or password!', 401))
    }
    
    // console.log(email);
    // console.log('**********',correctPassword);
    const token = signToken(user.id)
    res.status(200).json({
        status: 'success',
        token
    })
    //const token = jwt.sign({id: }) ;
}

// exports.protect = (req, res, next) => {
//     next();
// }