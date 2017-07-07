
var map;
var marker;
function initMap() {
    //create a map object and specify the DOM element for display
    var latLng = {lat: getVLat(), lng:getVLon()};//new google.maps.LatLng(@ViewBag.VLat, @ViewBag.VLon);
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
setInterval(function(){
   //toggleBounce();
   var tempP = {lat: getVLat() + Math.random() / 1000, lng:getVLon() + + Math.random() / 1000};
   //var tempP = {lat: getVLat(), lng:getVLon()};
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
   document.getElementById('LatTitle').innerHTML = "Latitude:" + tempP.lat;
   document.getElementById('LonTitle').innerHTML = "Longtitude:" + tempP.lng;
   
   //initMap();
}, 2000);

