(function (cibertec2) {
    window.cibertec2.getLocation = function () {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(showPosition);
        }
    }

    function showPosition(position) {
        //var location = { lat: position.coords.latitude, lng: position.coords.longitude };
        var location = { lat: -12.088662, lng: -77.064827};

        var map = new google.maps.Map(document.getElementById("googleMap2"), {
            zoom: 15,
            center: location
        });
        var marker = new google.maps.Marker({
            position: location,
            map: map,
            title: 'cibertec2!'
        });
    }
})(window.cibertec2 = window.cibertec2 || {});