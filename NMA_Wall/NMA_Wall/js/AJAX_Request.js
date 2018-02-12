// AJAX data from mobile app

function GetData(url, cbFunction) {
    var xhttp = null;

    if (window.XMLHttpRequest) {
        // modern browsers
        xhttp = new XMLHttpRequest();
    } else {
        // Old IE browsers
        xhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xhttp.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            cbFunction(this);
        }
    };
    /*
    xhttp.open("GET", "URL/ajax_info.txt", true);
    xhttp.send();
    /**/
}

function PostData(url, cbFunction, data) {
    var xhttp = null;

    if (window.XMLHttpRequest) {
        // modern browsers
        xhttp = new XMLHttpRequest();
    } else {
        // Old IE browsers
        xhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xhttp.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            cbFunction(this);
        }
    };
    /*
    xhttp.open("POST", "URL/...", true, "user", "password");
    xhttp.send();
    /**/
}