let currentPage = 1;
const pageSize = 10;

function loadDistrictData(page) {
    currentPage = page;
    const xhr = new XMLHttpRequest();
    xhr.open('POST', '/YourPage.aspx/event_app_pay_list', true);
    xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
    xhr.onload = function () {
        if (xhr.status === 200) {
            document.getElementById("tblDistrict").innerHTML = xhr.responseText;
            updatePaginationButtons();
        }
    };
    xhr.send('pageNumber=' + page + '&pageSize=' + pageSize);
}

function updatePaginationButtons() {
    const prevButton = document.getElementById("prevDistrict");
    const nextButton = document.getElementById("nextDistrict");

    if (currentPage <= 1) {
        prevButton.disabled = true;
    } else {
        prevButton.disabled = false;
    }
    nextButton.disabled = false;
}

document.getElementById("prevDistrict").addEventListener("click", function () {
    if (currentPage > 1) {
        loadDistrictData(currentPage - 1);
    }
});

document.getElementById("nextDistrict").addEventListener("click", function () {
    loadDistrictData(currentPage + 1);
});
loadDistrictData(currentPage);
