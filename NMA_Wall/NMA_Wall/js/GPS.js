$(function () {
    var options = {
        enableHighAccuracy: true
    };

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showLocation, posError, options);
    } else
        NolocationAvaliable();

    function showLocation(position) {
        var coords = position.coords;

        //confirm("Latitude: " + coords.latitude);
        //confirm("Longitude: " + coords.longitude);
    }

    function posError(position) {
        switch (position.code) {
            case 0: // Unknown Error
                NolocationAvaliable();
                break;
            case 1: // Permission Denied
                NolocationAvaliable();
                break;
            case 2: // Unable to get Position

                break;
            case 3: // Timed Out
                NolocationAvaliable();
                break;
            default:
                break;
        }
    }


});