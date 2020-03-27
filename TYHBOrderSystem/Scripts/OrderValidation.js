function IsValidPhoneNumber(str) {
    var phoneExpression = /^[7-9]\d{9}$/;
    return phoneExpression.test(str);
}