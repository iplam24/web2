<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="index.WebForm1" %>

     <!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    <meta content="INDEX,FOLLOW" name="robots">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Điện thoại chính hãng</title>
    <link rel="stylesheet" href="css/main.css">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.2/css/all.min.css" rel="stylesheet">
</head>
<body>


   
    <script>
        // Lấy tất cả các phần tử văn bản trên trang
        const textElements = document.querySelectorAll('h1, h2, h3, p, span, a');

        // Thêm sự kiện khi nhấn và thả chuột
        textElements.forEach(element => {
            element.addEventListener('mousedown', () => {
                element.style.color = '#ff6600'; // Đổi màu chữ khi nhấn
            });

            element.addEventListener('mouseup', () => {
                element.style.color = '#000000'; // Trả về màu mặc định
            });
        });

    </script>
    <form id="form1" runat="server">
        <!-- Header -->
        <div class="header">
            <div class="container">
                <div class="header-logo">
                    <a href="/">
                        <img src="img/logo2.jpg" alt="Điện thoại chính hãng" class="logo-img">
                    </a>
                </div>
                <h1 class="header-title">Điện thoại chính hãng</h1>
                <div class="header-search">
                    <input type="text" placeholder="Tìm kiếm ...." class="search-input">
                    <button class="search-btn">Tìm kiếm</button>
                </div>
                <div class="header-options">
                    <a href="admin/admin.aspx" class="header-option">
                        <p>
                            <i class="fa-solid fa-user" style="font-size:20px;margin-right:2px"></i>
                            <span>Đăng nhập</span>
                        </p>
                    </a>
                    <a href="/cart" class="header-option">
                        <p>
                            <i class="fa-solid fa-cart-shopping" style="font-size:20px;margin-right:2px"></i>
                            <span">Giỏ hàng</span>
                        </p>
                    </a>
                </div>
            </div>
            <nav class="header-nav">
                <ul class="nav-menu">
                    <li><a href="/">Trang Chủ</a></li>
                    <li><a href="/product">Điện thoại</a></li>
                    <li><a href="/Laptops">Laptop</a></li>
                    <li><a href="/accesories">Phụ Kiện</a></li>
                    <li><a href="/sale">Khuyến Mãi</a></li>
                    <li><a href="/contact">Liên Hệ</a></li>
                </ul>
            </nav>
        </div>
         <div class="image-container">
         <img src="img/header1.jpg" alt="header" />
 </div>

    <h2></h2>
   

    <div class="slideshow-container">

        <div class="mySlides fade">
           
            <img src="img/img1.jpg" style="width:100%">
        </div>

        <div class="mySlides fade">
            
             <img src="img/imgjs1.png" style="width:100%">
      
        </div>

        <div class="mySlides fade">
            <img src="img/img(4).jpg" style="width:100%">
        </div>

        <div class="mySlides fade">
            <img src="img/imgjs(3).jpg" style="width:100%">
        </div>

    </div>
    <br>

    <div style="text-align:center">
        <span class="dot" onclick="currentSlide(1)"></span>
        <span class="dot" onclick="currentSlide(2)"></span>
        <span class="dot" onclick="currentSlide(3)"></span>
        <span class="dot" onclick="currentSlide(4)"></span>
    </div>

    <script>
        let slideIndex = 0;
        showSlides();

        function showSlides() {
            let i;
            let slides = document.getElementsByClassName("mySlides");
            let dots = document.getElementsByClassName("dot");
            for (i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }
            slideIndex++;
            if (slideIndex > slides.length) {
                slideIndex = 1;
            }
            for (i = 0; i < dots.length; i++) {
                dots[i].className = dots[i].className.replace(" active", "");
            }
            slides[slideIndex - 1].style.display = "block";
            dots[slideIndex - 1].className += " active";
            setTimeout(showSlides, 5000); // Change image every 5 seconds
        }

        function currentSlide(n) {
            let i;
            let slides = document.getElementsByClassName("mySlides");
            let dots = document.getElementsByClassName("dot");
            for (i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }
            for (i = 0; i < dots.length; i++) {
                dots[i].className = dots[i].className.replace(" active", "");
            }
            slides[n - 1].style.display = "block";
            dots[n - 1].className += " active";
            slideIndex = n;
        }
    </script>
    <div class="product-container">
            <h1 class="featured-title">Sản phẩm nổi bật</h1>
            <div class="product-grid">
            <asp:Repeater ID="RepeaterProducts" runat="server">
                <ItemTemplate>
                    
                        <div class="product-item">
                            <img class="product-image" src='<%#"/admin/"+Eval("HinhAnh1")%>' alt='<%# Eval("TenSP") %>' />

                            <h3 class="product-name"><%# Eval("TenSP") %></h3>
                            <p class="product-price"><%# String.Format("{0:0,0 VNĐ}", Eval("GiaBan")) %></p>
                            <button class="btn-add-to-cart">Thêm vào giỏ hàng</button>
                        </div>
                    
                </ItemTemplate>
            </asp:Repeater>
        </div>
       </div>
<div class="slider-container">
    <button class="prev-btn"></button>
    <div class="slide">
        <!--h1-->
        <div class="slide">
            <div class="slide"><img src="img/cd5.jpg" alt="cd5" /></div>
        </div>
    </div>
     <div class="product-container">
    <h1 class="featured-title">Sản phẩm nổi bật</h1>
   
</div>
</div>
        <!--- Gợi ý cho bạn --->
<div class="suggested-container">
    <h2 class="suggested-title">Gợi ý cho bạn </h2>
    <div class="suggested-grid">
        <div class="suggested-item">
            <img class="product-image" src="img/dellinspironi5.jpg" alt="Dell inspiron 15 3520 i5" />
            <h3 class="product-name">Dell inspiron 15 3520 i5</h3>
            <p class="product-price">20.000.000 VNĐ</p>
            <button class="btn-add-to-cart">Thêm vào giỏ hàng</button>
        </div>
        <div class="suggested-item">
            <img class="product-image" src="img/Hp245.jpg" alt="HP 245 G10 R5 7530U" />
            <h3 class="product-name">HP 245 G10 R5 753U</h3>
            <p class="product-price">12.490.000 VNĐ</p>
            <button class="btn-add-to-cart">Thêm vào giỏ hàng </button>
        </div>
        <div class="suggested-item">
            <img class="product-image" src="img/neoi5.jpg" alt="neoi5" />
            <h3 class="product-name">Acer Predator Helios Neo PHN16 i5</h3>
            <p class="product-price">25.000.000 VNĐ</p>
            <button class="btn-add-to-cart">Thêm vào giỏ hàng</button>
     </div>
        <div class="suggested-item">
            <img class="product-image" src="img/AsusTUFGaming.jpg" alt="Asus TUF Gaming F15 FX507ZC4 i5" />
            <h3 class="product-name">Asus TUF Gaming F15 FX507ZC4 i5</h3>
            <p class="product-price">20.490.000 VNĐ</p>
            <button class="btn-add-to-cart">Thêm vào giỏ hàng</button>
        </div>
        <div class="suggested-item">
            <img class="product-image" src="img/LenovoGaming.jpg" alt="Lenovo Gaming LOQ 15ARP9 R7 " />
            <h3 class="product-name">Lenovo Gaming LOQ 15ARP9 R7 </h3>
            <p class="product-price">26.490.000 VNĐ</p>
            <button class="btn-add-to-cart">Thêm vào giỏ hàng </button>
        </div>
</div>
</div>
    <!-- h2--->
        <div class="slide">
        <div class="slide"><img src="img/cd3.jpg"alt=" cd3" />
    </div>
</div>

        <!--- phụ kiện chính hãng --->
        <div class="accessories-container">
            <h2 class="accessories-title">Phụ kiện chính hãng</h2>
            <div class="accessories-grid">
                <!--- Phụ kiện 1-->
                <div class="accessories-item">
                    <img class="accessory-image" src="img/taiNgheBluetooth.jpg" alt="Tai nghe chụp tai bluetooth" />
                    <h3 class="accessory-name">Tai nghe chụp tai bluetooth sony</h3>
                    <p class="accessory-price">500.000 VNĐ</p>
                    <button class="btn-add-to-cart">Thêm vào giỏ hàng</button>
                </div>
                <!--- PK2--->
                <div class="accessories-item">
                    <img class="accessory-image" src="img/TaiNgheBluetoothTrue.jpg" alt="Tai nghe bluetooth true" />
                    <h3 class="accessory-name">Tai nghe Bluetooth true wireless</h3>
                    <p class="accessory-price">990.000 VNĐ</p>
                      <button class="btn-add-to-cart">Thêm vào giỏ hàng</button>
                </div>
                <!---PK3-->
                <div class="accessories-item">
                     <img class="accessory-image" src="img/Cusac2cong.jpg" alt="Củ sạc type C 2 cổng " />
                    <h3 class="accessory-name">Củ xạc Type C 2 cổng 35W MNWP3ZA-A</h3>
                     <p class="accessory-price"> 1.190.000 VNĐ</p>
                     <button class="btn-add-to-cart">Thêm vào giỏ hàng</button>
                </div>

        </div>
            </div>
        <!-- Footer -->
        <footer class="footer">
            <div class="footer-container">
                <div class="footer-column">
                    <h3>Thông đại hỗ trợ</h3>
                    <ul>
                        <li><a href="tel:1900232460">Gọi mua: 1900 232 460</a></li>
                        <li><a href="tel:18001062">Khiếu nại: 1800 1062</a></li>
                        <li><a href="tel:1900232464">Bảo hành: 1900 232 464</a></li>
                    </ul>
                </div>
                <div class="footer-column">
                    <h3>Về công ty</h3>
                    <ul>
                        <li><a href="#">Thông tin công ty</a></li>
                        <li><a href="#">Tuyển dụng</a></li>
                        <li><a href="#">Gửi góp ý</a></li>
                    </ul>
                </div>
                <div class="footer-column">
                    <h3>Thông tin khác</h3>
                    <ul>
                        <li><a href="#">Tích điểm Quà tặng VIP</a></li>
                        <li><a href="#">Lịch sử mua hàng</a></li>
                        <li><a href="#">Chính sách bảo hành</a></li>
                    </ul>
                </div>
            </div>
            <div class="footer-bottom">
                <p>&copy; Điện thoại chính hãng - Uy tín hàng đầu</p>
            </div>
        </footer>
    </form>
</body>
</html>
