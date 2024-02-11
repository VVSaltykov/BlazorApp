window.blazorExtensions = {
    SetCookie: function (name, value, seconds) {
        var expires = new Date();
        expires.setTime(expires.getTime() + (seconds * 1000));
        document.cookie = name + "=" + escape(value) + ";expires=" + expires.toUTCString() + ";path=/";
    },
    GetCookie: function (name) {
        let cookieArray = document.cookie.split(';');
        for (let i = 0; i < cookieArray.length; i++) {
            let cookiePair = cookieArray[i].split('=');
            if (name == cookiePair[0].trim()) {
                return decodeURIComponent(cookiePair[1]);
            }
        }
        return null;
    }
};