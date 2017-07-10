
var map;
var marker;
var initLatLng;
function initMap() {
    //create a map object and specify the DOM element for display

    var latLng = { lat: -27.4698, lng: 153.0251 };//new google.maps.LatLng(@ViewBag.VLat, @ViewBag.VLon);
    map = new google.maps.Map(document.getElementById('VehicleMonitorV1Map'), {
        center: latLng,//required
        //scrollwheel: false,
        zoom: 15 //required
    });
    //var image = "\Resources\Images\Icons\car.png";
    //var image = "/Resources/Images\Icons/car.png";
    //var image = 'C:\ASPNETMVC5Learn\VehicleMonitorV1\VehicleMonitorV1\Resources\Images\Icons';
    marker = new google.maps.Marker({
         position: latLng,
         map: map,
         draggable: true,
         label: "A", //information to be shown from model layer
         //title: "Vehicle Lat:" + latLng,//information to be shown from model layer
         //animation: google.maps.Animation.DROP,
         //icon: image
    });
    //marker.setIcon();
    marker.addListener('click', toggleBounce);
   
}

function toggleBounce() {
    if (marker.getAnimation() !== null) {
        marker.setAnimation(null);
    } else {
        marker.setAnimation(google.maps.Animation.BOUNCE);
    }
    
}

function OnTestButton() {
    //toggleBounce();
    document.getElementById('Test').innerHTML = "TEST BUTTON CLICKED";
    //refreshPosition();
    //document.getElementById('clear').innerHTML = "clicked";
    /*
    if (marker.getMap() === null) {
        marker.setMap(map);
        document.getElementById('clear').innerHTML = "Display the Marker";
    } else {
        marker.setMap(null);
        document.getElementById('clear').innerHTML = 'Hide the Marker';
    }*/
    
}
setInterval(function () {
    
    refreshPosition();
}, 2000);
function refreshPosition() {
    $.ajax({
        url: '/Map/Position',
        type: 'GET',
        //data: 'String',
        //dataType: "Json",
        //contentType: "application/json; charset=utf-8",
        success: function (response) {
            //var obj = JSON.parse(response);
            //alert(response);
            var tempP = {
                lat: response.Latitude, lng: response.Longitude
            };
            document.getElementById('LatTitle').innerHTML = "Latitude:" + tempP.lat;//response.Latitude;
            document.getElementById('LonTitle').innerHTML = "Longitude:" + tempP.lng;//response.Longtitude;
            refreshMarker(tempP);
        },
        error: function (error) {
            $(this).remove();
            DisplayError(error.statusText);
        }
    });
}
function refreshMarker(tempP) {
    marker.setMap(null);
    map.center = tempP;
    marker = new google.maps.Marker({
        position: tempP,
        map: map,
        //draggable: true,
        label: "A", //information to be shown from model layer
        //title: "Vehicle Lat:" + latLng,//information to be shown from model layer
        //animation: google.maps.Animation.DROP,
        //icon: image
    });
    marker.animation = google.maps.Animation.DROP;
}

