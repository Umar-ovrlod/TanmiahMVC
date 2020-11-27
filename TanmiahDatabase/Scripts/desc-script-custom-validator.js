$(document).ready(function () {
    $('#descform').validate({
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
            'DescTitle': {
                required: true,
                minlength: 20
            },

            'DescText': {
                required: true,
                minlength: 20
            },

            'DescDec': {
                required: true,
                minlength: 20
            },

            'PerPack': {
                required: true,
                minlength: 3
            },

            'Energy': {
                required: true,
                minlength: 2
            },

            'Carbo': {
                required: true,
                minlength: 2
            },

            'Protiens': {
                required: true,
                minlength: 2
            },

            'Fat': {
                required: true,
                minlength: 2
            },

            'ProtiensPerPack': {
                required: true,
                minlength: 2
            },

            'FatPerPack': {
                required: true,
                minlength: 2
            },

            'ProductID': {
                required: true,
            },
        },
        messages: {
            'DescTitle': {
                required: 'Please provide a DescTitle',
                minlength: 'Desc Title must be at least 20 characters long'
            },

            'DescText': {
                required: 'Please provide a DescText',
                minlength: 'Desc Text must be at least 20 characters long'
            },

            'DescDec': {
                required: 'Please provide a description Dec',
                minlength: 'Description dec must be at least 20 characters long'
            },

            'PerPack': {
                required: 'Please provide a PerPack',
                minlength: 'PerPack must be at least 3 characters long'
            },


            'Energy': {
                required: 'Please provide a Energy',
                minlength: 'Energy must be at least 2 characters long'
            },

            'Carbo': {
                required: 'Please provide a Carbohydrates',
                minlength: 'Carbohydrates must be at least 2 characters long'
            },

            'Protiens': {
                required: 'Please provide a Protiens',
                minlength: 'Protiens must be at least 2 characters long'
            },

            'Fat': {
                required: 'Please provide a Fat',
                minlength: 'Fat must be at least 2 characters long'
            },

            'ProtiensPerPack': {
                required: 'Please provide a Protiens Per Pack',
                minlength: 'Protiens Per Pack must be at least 2 characters long'
            },

            'FatPerPack': {
                required: 'Please provide a Fat Per Pack',
                minlength: 'Fat Per Pack must be at least 2 characters long'
            },


            'ProductID': {
                required: 'Please provide a ProductID',
            },

        },
        }
    });
});   