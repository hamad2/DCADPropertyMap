//AIzaSyCNAjZpcC_Fn_Bf6YSp8lnc5e98CkcUMKs
window.initializeMap = () => {
    require([
        "esri/Map",
        "esri/views/MapView",
        "esri/layers/TileLayer",
        "esri/layers/FeatureLayer",
        "esri/widgets/Search",
        "esri/widgets/ScaleBar",
        "esri/widgets/Compass",
        "esri/widgets/Home",
        "esri/widgets/Zoom",
        "esri/geometry/Point"
    ], function (Map, MapView, TileLayer, FeatureLayer, Search, ScaleBar, Compass, Home, Zoom, Point) {
        var parcelLayer = new FeatureLayer({
            url: "https://maps.dcad.org/prdwa/rest/services/Property/ParcelQuery/MapServer/4"
        });

        var tileLayer = new TileLayer({
            url: "https://maps.dcad.org/prdwa/rest/services/Property/PropMap/MapServer"
        });

        var map = new Map({
            basemap: {
                baseLayers: [tileLayer]
            },
            layers: [parcelLayer]
        });

        var view = new MapView({
            container: "map",
            map: map,
            center: [-96.7969, 32.7763], // Longitude, latitude of Dallas
            zoom: 11 // Set the zoom level directly
        });

        var searchWidget = new Search({
            view: view,
            container: "search-container", // Add the search widget to the sidebar
            sources: [{
                layer: parcelLayer,
                searchFields: ["PARCELID", "SITEADDRESS", "OWNERNME1"],
                displayField: "SITEADDRESS",
                exactMatch: false,
                outFields: ["PARCELID", "SITEADDRESS", "OWNERNME1"],
                name: "Parcels",
                placeholder: "Search by Parcel ID, Address, or Owner",
                maxResults: 6,
                maxSuggestions: 6,
                suggestionsEnabled: true,
                minSuggestCharacters: 0
            }]
        });

        searchWidget.on("search-complete", function (event) {
            if (event.results.length > 0) {
                var firstResult = event.results[0].results[0];
                var attributes = firstResult.feature.attributes;
                var location = firstResult.feature.geometry;

                // Ensure location is a Point
                if (location.type !== "point") {
                    location = location.extent.center;
                }

                view.goTo({
                    target: location,
                    zoom: 18
                }).then(function () {
                    addParcelIdDiv(attributes.PARCELID);
                    addGoogleMapImage(location);
                });
            }
        });

        // Remove the search widget from the map UI
        view.ui.remove(searchWidget);

        // Add ScaleBar widget to the bottom left of the view
        var scaleBar = new ScaleBar({
            view: view,
            unit: "dual" // The scale bar displays both metric and non-metric units.
        });
        view.ui.add(scaleBar, {
            position: "bottom-left"
        });

        // Add Compass widget to the top left of the view
        var compass = new Compass({
            view: view
        });
        view.ui.add(compass, {
            position: "top-left"
        });

        // Add Home widget to the top left of the view
        var homeBtn = new Home({
            view: view
        });
        view.ui.add(homeBtn, {
            position: "top-left",
            index: 1
        });

        // Add customized Zoom widget
        var zoom = new Zoom({
            view: view
        });
        view.ui.add(zoom, {
            position: "top-left"
        });

        function addParcelIdDiv(parcelId) {
            var parcelIdDiv = document.getElementById("parcel-id-div");
            if (parcelIdDiv) {
                parcelIdDiv.innerHTML = `<a href="/details/${parcelId}" target="_blank">Parcel ID: ${parcelId}</a>`;
            }
        }


        function addGoogleMapImage(location) {
            var googleImageDiv = document.getElementById("google-image");
            if (googleImageDiv) {
                googleImageDiv.innerHTML = '';
                var lat = location.latitude;
                var lng = location.longitude;
                var img = document.createElement("img");
                img.src = `https://maps.googleapis.com/maps/api/staticmap?center=${lat},${lng}&zoom=18&size=300x200&maptype=streetview&key=AIzaSyCNAjZpcC_Fn_Bf6YSp8lnc5e98CkcUMKs`;
                img.style.width = "100%";
                img.style.border = "1px solid #ccc";
                googleImageDiv.appendChild(img);
            }
        }
    });
};

window.toggleSidebar = () => {
    const sidebar = document.getElementById('sidebar');
    const toggle = document.getElementById('sidebar-toggle');
    sidebar.classList.toggle('collapsed');
    if (sidebar.classList.contains('collapsed')) {
        toggle.innerHTML = '&#10095;'; // Change to arrow pointing right
        document.getElementById('map-container').style.marginLeft = '0';
    } else {
        toggle.innerHTML = '&#10094;'; // Change to arrow pointing left
        document.getElementById('map-container').style.marginLeft = '300px';
    }
};
