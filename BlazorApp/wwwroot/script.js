window.blazorExtensions = {
    SetCookie: function (name, value, seconds) {
        var expires = new Date();
        expires.setTime(expires.getTime() + (seconds * 1000));
        document.cookie = name + "=" + escape(value) + ";expires=" + expires.toUTCString() + ";path=/";
    }
};