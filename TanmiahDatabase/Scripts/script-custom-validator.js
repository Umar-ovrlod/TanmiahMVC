$(document).ready(function () {
    $('#bannerform').validate({
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
            'ProductType': {
                required: true,
                minlength: 5
            },

            'ProductTitle': {
                required: true,
                minlength: 10
            },

            'ProductDescription': {
                required: true,
                minlength: 20
            },

            'ProductImage': {
                required: true,
                minlength: 5
            },
        },
        messages: {
            'ProductType': {
                required: 'Please provide a product type',
                minlength: 'Product Type must be at least 5 characters long'
            },

            'ProductTitle': {
              required: 'Please provide a product title',
                minlength: 'Product Title must be at least 10 characters long'
            },

            'ProductDescription': {
               required: 'Please provide a product description',
                minlength: 'Product Description must be at least 20 characters long'
            },

            'ProductImage': {
              required: 'Please provide a product Image',
                minlength: 'Product Image must be at least 20 characters long'
            },

        }
    });
});   