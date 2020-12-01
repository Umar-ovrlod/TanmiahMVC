$(document).ready(function () {
    $('#cardform').validate({
        errorClass: 'help-block animation-slideDown', // You can change the animation class for a different entrance animation - check animations page  
        errorElement: 'div',
        errorPlacement: function (error, e) {
            e.parents('.form-group > div').append(error);
        },
        highlight: function (e) {

            $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
            $(e).closest('.help-block').remove();
        },
        success: function (e) {
            e.closest('.form-group').removeClass('has-success has-error');
            e.closest('.help-block').remove();
        },
        rules: {
            'CardImage': {
                minlength: 20
            },

            'ShortDescription': {
                required: true,
                minlength: 20
            },

            'ShortText': {
                required: true,
                minlength: 25
            },

            'ProductID': {
                required: true,
               // minlength: 1
            },
        },
        messages: {
            'CardImage': {
                required: 'Please provide a card image',
                minlength: 'Card Image must be at least 20 characters long'
            },

            'ShortDescription': {
                required: 'Please provide a short description',
                minlength: 'Short Description must be at least 20 characters long'
            },

            'ShortText': {
                required: 'Please provide a short text',
                minlength: 'Short Text must be at least 25 characters long'
            },

            'ProductID': {
                required: 'Please provide a product ID',
                minlength: 'Product ID must be at least 1 characters long'
            },

        }
    });
});   