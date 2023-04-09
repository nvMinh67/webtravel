
// mobile menu
// var offmenu = document.getElementById("mySidepanel");

function openNav() {
  document.getElementById("mySidepanel").style.width = "250px";
}

function closeNav() {
  document.getElementById("mySidepanel").style.width = "0";
  document.body.style.backgroundColor = "white";
  document.body.style.cursor = "default";
}

var dropdown = document.getElementsByClassName("dropdown-btn");
var i;

for (i = 0; i < dropdown.length; i++) {
  dropdown[i].addEventListener("click", function() {
    this.classList.toggle("active");
    var dropdownContent = this.nextElementSibling;
    if (dropdownContent.style.display === "block") {
      dropdownContent.style.display = "none";
    } else {
      dropdownContent.style.display = "block";
    }
  });
}

// Initialize Swiper
  var swiper = new Swiper(".mySwiper", {
    centeredSlides: true,
    loop: true,
    autoplay: {
      delay: 2500,
      disableOnInteraction: false,
    },
    pagination: {
      el: ".swiper-pagination",
      clickable: true,
    },
    navigation: {
      nextEl: ".swiper-button-next",
      prevEl: ".swiper-button-prev",
    },
  });

  $( function() {
    $( "#datepicker" ).datepicker();
  } );

  var swiper = new Swiper(".mySwiper-slider", {
    slidesPerView: 1,
    spaceBetween: 10,
    loop: true,
    pagination: {
      el: ".swiper-pagination",
      clickable: true
    },
    navigation: {
      nextEl: ".swiper-button-next",
      prevEl: ".swiper-button-prev"
    },
    breakpoints: {
      "@0.00": {
        slidesPerView: 1,
        spaceBetween: 10
      },
      "@0.75": {
        slidesPerView: 2,
        spaceBetween: 20
      },
      "@1.00": {
        slidesPerView: 2,
        spaceBetween: 20
      },
      "@1.25": {
        slidesPerView: 3,
        spaceBetween: 100
      },
      "@1.50": {
        slidesPerView: 4,
        spaceBetween: 50
      }
    }
  });

  var swiper = new Swiper(".mySwiper-book", {
    slidesPerView: 1,
    spaceBetween: 0,
    loop: true,
    pagination: {
      el: ".swiper-pagination",
      clickable: true
    },
    navigation: {
      nextEl: ".swiper-button-next",
      prevEl: ".swiper-button-prev"
    },
    breakpoints: {
      "@0.00": {
        slidesPerView: 1,
        spaceBetween: 10
      },
      "@0.75": {
        slidesPerView: 2,
        spaceBetween: 20
      },
      "@1.00": {
        slidesPerView: 3,
        spaceBetween: 40
      },
      "@1.50": {
        slidesPerView: 4,
        spaceBetween: 50
      },
    }
  });

  var swiper = new Swiper(".mySwiper-reviews", {
    slidesPerView: 1,
    spaceBetween: 30,
    loop: true,
    keyboard: {
      enabled: true,
    },
    pagination: {
      el: ".swiper-pagination",
      clickable: true,
    },
    navigation: {
      nextEl: ".swiper-button-next",
      prevEl: ".swiper-button-prev",
    },
  });

  var swiper = new Swiper(".mySwiper-details", {
    loop: true,
    spaceBetween: 10,
    slidesPerView: 4,
    freeMode: true,
    watchSlidesProgress: true,
  });
  var swiper2 = new Swiper(".mySwiper2", {
    loop: true,
    spaceBetween: 10,
    navigation: {
      nextEl: ".swiper-button-next",
      prevEl: ".swiper-button-prev",
    },
    thumbs: {
      swiper: swiper,
    },
  });

  $(function () {
    $('[data-toggle="tooltip"]').tooltip('show')
  })

  function openDescription(evt, DesName) {
    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
      tabcontent[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
      tablinks[i].className = tablinks[i].className.replace(" active", "");
    }
    document.getElementById(DesName).style.display = "block";
    evt.currentTarget.className += " active";
  }

  document.getElementById("defaultOpen").click();

  $(document).ready(function() {
    $('.bar span').hide();
    $('#bar-five').animate({
       width: '75%'}, 1000);
    $('#bar-four').animate({
       width: '35%'}, 1000);
    $('#bar-three').animate({
       width: '20%'}, 1000);
    $('#bar-two').animate({
       width: '15%'}, 1000);
    $('#bar-one').animate({
       width: '30%'}, 1000);
    
    setTimeout(function() {
      $('.bar span').fadeIn('slow');
    }, 1000);
    
  });

  function payCash() {
    var x = document.getElementById("byCash");
    x.style.display = "block";
  }

  function payMomo() {
    var y = document.getElementById("byMomo");
    y.style.display = "block";
  }

  function payTransfer() {
    var z = document.getElementById("byTransfer");
    z.style.display = "block";
  }

  function payVNPAY() {
    var l = document.getElementById("byVNPay");
    l.style.display = "block";
  }

