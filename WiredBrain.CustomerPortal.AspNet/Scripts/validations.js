$.validator.addMethod('uppercase', function (value, element, params) {
    var minLength = parseInt(params);
    if (value.length < minLength)
        return true;
    return value === value.toUpperCase();
});

$.validator.unobtrusive.adapters.addSingleVal("uppercase", "minLength");