console.log(window.username);

(function ($) {
    const baseUrl = "https://localhost:7281";

    // Dropdown on mouse hover
    $(document).ready(function () {
        function toggleNavbarMethod() {
            if ($(window).width() > 992) {
                $('.navbar .dropdown').on('mouseover', function () {
                    $('.dropdown-toggle', this).trigger('click');
                }).on('mouseout', function () {
                    $('.dropdown-toggle', this).trigger('click').blur();
                });
            } else {
                $('.navbar .dropdown').off('mouseover').off('mouseout');
            }
        }
        toggleNavbarMethod();
        $(window).resize(toggleNavbarMethod);
    });


    // Back to top button
    $(window).scroll(function () {
        if ($(this).scrollTop() > 100) {
            $('.back-to-top').fadeIn('slow');
        } else {
            $('.back-to-top').fadeOut('slow');
        }
    });
    $('.back-to-top').click(function () {
        $('html, body').animate({ scrollTop: 0 }, 1500, 'easeInOutExpo');
        return false;
    });

    $('.quantity button').on('click', function () {
        let button = $(this);
        let numOfProd = button.parent().parent().find('input.num-of-prod');
        let orderId = button.parent().parent().find('input.order-id');
        let orderTotalPrice = $("#order-total-price-" + orderId.val());
        let totalCartPrice = $("#total-cart-price");
        let cartItemNum = $("#cart-item-num");
        let url = "";
        let actionType = "none";
        let myHeader = new Headers();
        let jwtToken = localStorage.getItem("jwtToken");
        myHeader.append("Authorization", jwtToken);
        console.log("Token", jwtToken);

        const changeProdNum = async (url) => {
            button.prop("disabled", true);
            let response = await fetch(url, {
                method: 'PATCH',
                headers: myHeader,
            });
            return response.json();
        }

        if (button.hasClass('btn-plus')) {
            url = baseUrl + "/Order/Incre/" + orderId.val();
            actionType = "incre";
            console.log("Incre order product number: " + url);
        }
        else {
            if (parseInt(numOfProd.val()) > 1) {
                url = baseUrl + "/Order/Sub/" + orderId.val();
                actionType = "sub";
                console.log("Sub order product number: " + url);
            }
        }
        console.log("Button: ", actionType);
        if (actionType !== "none") {
            changeProdNum(url)
                .then(data => {
                    console.log("Update succeeded: ", data);
                    let newTotal = data.numOfGood * data.productPrice
                    button.prop("disabled", false);
                    orderTotalPrice.html("$" + newTotal);
                    numOfProd.val(data.numOfGood);

                    let cartTotalPriceValue = parseInt(totalCartPrice.html().substring(1));
                    let productPriceValue = parseInt(data.productPrice);
                    let newCartTotal;
                    let newCartNum;

                    if (actionType === "incre") {
                        newCartTotal = cartTotalPriceValue + productPriceValue;
                        newCartNum = parseInt(cartItemNum.html()) + 1;
                        console.log(newCartNum);
                    }
                    else {
                        newCartTotal = cartTotalPriceValue - productPriceValue;
                        newCartNum = parseInt(cartItemNum.html()) - 1;
                        console.log(newCartNum);
                    }
                    totalCartPrice.html("$" + newCartTotal);
                    cartItemNum.html(newCartNum);
                });
        }
    });

    $("#btn-plus-new-order").on("click", () => {
        let button = $(this);
        let numOfProd = $("#new-order-prod-num");
        let oldValue = numOfProd.val();
        let newValue = parseInt(oldValue) + 1;

        console.log("new Value: ", newValue);
        numOfProd.val(newValue);
    })

    $("#btn-minus-new-order").on("click", () => {
        let button = $(this);
        let numOfProd = $("#new-order-prod-num");
        let oldValue = numOfProd.val();
        let newValue = parseInt(oldValue);

        if (oldValue > 1) {
            newValue = parseInt(oldValue) - 1;
        }

        console.log("new Value: ", newValue);
        numOfProd.val(newValue);
    })
})(jQuery);

function submitForm(formId) {
    let form = document.getElementById(formId);
    form.submit();
}

function setMinValue(minId, maxId) {
    let max = document.getElementById(maxId);
    let min = document.getElementById(minId);
    max.min = min.value;
    alert("set min: ", min.value);
}

function setMaxValue(minId, maxId) {
    var max = document.getElementById(maxId);
    var min = document.getElementById(minId);
    min.max = max.value;
    alert("set max: ", max.value);
}

const setCancelOrder = (orderId) => {
    let button = document.getElementById("confirmCancelBtn");
    button.value = orderId;
    console.log(button.value)
}

