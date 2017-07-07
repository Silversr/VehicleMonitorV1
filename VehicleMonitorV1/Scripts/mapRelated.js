var map;
var marker;
function initMap() {
    //create a map object and specify the DOM element for display
    var latLng = { lat: -27.4698, lng: 153.0251 };//new google.maps.LatLng(@ViewBag.VLat, @ViewBag.VLon);
    map = new google.maps.Map(document.getElementById('VehicleMonitorV1Map'), {
        center: latLng,//required
        //scrollwheel: false,
        zoom: 15 //required
    });
    
     marker = new google.maps.Marker({
         position: latLng,
         map: map,
         draggable: true,
         label: "A", //information to be shown from model layer
         title: "Vehicle A", //information to be shown from model layer
         animation: google.maps.Animation.DROP
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

function clear() {
    document.getElementById('clear').innerHTML = "clicked";
    /*
    if (marker.getMap() === null) {
        marker.setMap(map);
        document.getElementById('clear').innerHTML = "Display the Marker";
    } else {
        marker.setMap(null);
        document.getElementById('clear').innerHTML = 'Hide the Marker';
    }*/
    
}

