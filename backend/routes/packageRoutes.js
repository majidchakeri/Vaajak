const express = require('express');
const contentController = require('../controllers/packageController');
const authController = require('../controllers/authController');

const router = express.Router();

router.route('/content').get(authController.protect, contentController.getposts);
