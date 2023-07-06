// function to ask for prediction from the server
function getIsReal(userInput) {
return fetch(`Index?handler=AnalyzeNews&text=${userInput}`)
    .then((response) => {
        return response.text();
    })
}

function updateMarker(markerPosition, isReal) {
    $("#markerPosition").attr("style", `left:${markerPosition}%`);
    $("#markerValue").text(isReal);
}

function updateIsReal() {

    var userInput = $("#Message").val();

    getIsReal(userInput)
        .then((isReal) => {
            switch (isReal) {
                case "Real":
                    updateMarker(100.0, isReal);
                    break;
                case "Fake":
                    updateMarker(0.0, isReal);
                    break;
                default:
                    updateMarker(45.0, "Checking");
            }
        });
} 

$("#Message").on('change input paste', updateIsReal)        

