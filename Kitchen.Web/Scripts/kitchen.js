var kitchen = (function () {
    function loadFindUsOnMap(containerId) {
        var mapDiv = document.getElementById(containerId);
        var map = new google.maps.Map(mapDiv, {
            center: { lat: 44.540, lng: -78.546 },
            zoom: 8
        });
    };

    return {
        loadFindUsOnMap: loadFindUsOnMap,
    };
})();