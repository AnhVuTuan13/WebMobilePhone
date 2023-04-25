using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMobilePhone_Models.Models;
using WebMobilePhone_Models.Common;

namespace WebMobilePhone_DataAccess.Configurations
{
    public static class ApplicationInitializer
    {
        private static readonly ComonFunction comonFunction = new ComonFunction();
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discount>().HasData(
              new Discount { Id = 1, PercentDiscount = 5, StartDate = DateTime.ParseExact("24/03/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture), EndDate = DateTime.ParseExact("24/07/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture) }
             );
            modelBuilder.Entity<Categories>().HasData(
                new Categories { Id = 1, Name = "IPhone" },
                new Categories { Id = 2, Name = "Samsung" },
                new Categories { Id = 3, Name = "Xiaomi" },
                new Categories { Id = 4, Name = "OPPOP" },
                new Categories { Id = 5, Name = "Nokia" }
                );

            modelBuilder.Entity<Products>().HasData(
                // Add Iphone
                new Products
                {
                    ID = 1,
                    Name = "iPhone 14 Pro Max 128GB | Chính hãng VN/A",
                    CategoryID = 1,
                    Decription = "<b>iPhone 14 Pro Max</b> là mẫu flagship nổi bật nhất của Apple trong lần trở lại năm 2022 với nhiều cải tiến về công nghệ cũng như vẻ ngoài cao cấp, sang chảnh hợp với gu thẩm mỹ đại chúng. Những chiếc điện thoại đến từ nhà Táo Khuyết nhận được rất nhiều sự kỳ vọng của thị trường ngay từ khi chưa ra mắt. Vậy liệu những chiếc flagship đến từ công ty công nghệ hàng đầu thế giới này có làm bạn thất vọng? Cùng khám phá những điều thú vị về iPhone 14 Pro Max ở bài viết dưới đây nhé.",
                    Content = "<br><br>" +
                    "iPhone năm nay sẽ được thừa hưởng nét đặc trưng từ người anh iPhone 13 Pro Max, vẫn sẽ là khung thép không gỉ và mặt lưng kính cường lực kết hợp với tạo hình vuông vức hiện đại thông qua cách tạo hình phẳng ở các cạnh và phần mặt lưng." +
                    "<br><br> "
                    + comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/251192/Slider/iphone-14-pro-max-tong-quan-1020x570.jpg") +
                    "<br><br> " +
                    "Sau nhiều thế hệ liên tiếp giữ thiết kế tai thỏ, cuối cùng Apple đã có đột phá trong thiết kế để chiều lòng người hâm mộ. Theo đó, ở mặt trước của những chiếc iPhone 14 Pro Max nơi có chiếc tai thỏ quen thuộc này đã được thay thế bằng thiết kế viên thuốc độc đáo. Viên thuốc trên màn hình iPhone 14 Pro Max là nơi chứa camera face ID và camera trước." +
                    "<br><br> " +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/251192/Slider/vi-vn-iphone-14-pro-max-up-3.jpg") +
                    "Thiết kế màn hình Dynamic Island mới này sẽ đưa các thông báo vào trong thiết kế viên thuốc để các hoạt động trên màn hình diễn ra liền mạch. Cụ thể các thông báo cuộc gọi, nghẹ sẽ được thích hợp vào trong thiết kế mới này và người dùng có thể thực hiện các thao tác chạm vuốt mở rộng, trở về trang chủ khi cần thiết.Cảm biến tiện cậm được Apple thiết kế lại và di chuyển ra phía sau màn hình nhờ đó mang lại không gian hiển thị rộng hơn. Camera TrueDepth cũng được thiết kế nhỏ hơn tới 31% so với thế hệ tiền nhiệm." +
                    "<br><br>" +
                    "Điểm ấn tượng nhất trên điện thoại iPhone năm nay nằm ở thiết kế màn hình, có thể dễ dàng nhận thấy được là hãng cũng đã loại bỏ cụm tai thỏ truyền thống qua bao đời iPhone bằng một hình dáng mới vô cùng lạ mắt. " +
                    "<br><br> " +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/251192/Slider/vi-vn-iphone-14-pro-max-up-6.jpg") +
                    "So với cụm tai thỏ hình notch năm nay đã có phần tiết kiệm diện tích tương đối tốt, nhưng khi so với các kiểu màn hình dạng “nốt ruồi” thì đây vẫn chưa thực sự là một điều quá tối ưu cho phần màn hình. Thế nhưng Apple lại rất biết cách tận dụng những nhược điểm để biến chúng trở thành ưu điểm một cách ngoạn mục bằng cách phát minh nhiều hiệu ứng thú vị." +
                    "<br><br>" +
                    "Để làm cho chúng trở nên bắt mắt hơn Apple cũng đã giới thiệu nhiều hiệu ứng chuyển động nhằm làm tăng sự thích thú cho người dùng, điều này được kích hoạt trong lúc mình ấn giữ phần hình notch khi đang dùng các phần mềm hỗ trợ như: Nghe nhạc, đồng hồ hẹn giờ, ghi âm,... " +
                    "<br><br> " +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/251192/Slider/vi-vn-iphone-14-pro-max-up-12.jpeg") +
                    "Từ trước đến nay, tấm nền OLED luôn được cộng đồng người dùng đánh giá rất cao khi xuất hiện trên các dòng sản phẩm của Apple, với chiếc iPhone 14 Pro Max điều này cũng không là ngoại lệ khi hình ảnh mà máy mang lại hết sức chân thực." +
                    "<br><br> " +
                    "Điểm vượt trội nhất mà các loại tấm nền khác khó mà đạt được là độ chuẩn các về màu sắc cao, mình cũng đã sử dụng iPhone 14 Pro Max để thiết kế một vài ấn phẩm như poster hay sticker đơn giản và thành quả lúc in ra sau khi đối chiếu lại với ảnh trên điện thoại thì gần như là bằng nhau, độ sai lệch không quá đáng kể giúp mình an tâm hơn trong việc thiết kế hình ảnh.",
                    Hot = 1,
                    Photo = "iPhone14ProMax128GB.webp",
                    Price = 29990000,
                    DiscountID = 1,
                    Amount = 50
                },
                new Products
                {
                    ID = 2,
                    Name = "iPhone 13 128GB | Chính hãng VN/A",
                    CategoryID = 1,
                    Decription = "Cuối năm 2020, bộ 4 iPhone 12 đã được ra mắt với nhiều cái tiến. Sau đó, mọi sự quan tâm lại đổ dồn vào sản phẩm tiếp theo – iPhone 13. Vậy iP 13 sẽ có những gì nổi bật, hãy tìm hiểu ngay sau đây nhé!",
                    Content = "<br><br> " + comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/223602/Slider/vi-vn-iphone-13-up-3.jpg") +
                    "<br><br>" +
                    "iPhone 13 có một sự thay đổi lớn về camera so với trên iPhone 12 Series. Cụ thể, iPhone có thể được trang bị ống kính siêu rộng mới giúp máy hiển thị được nhiều chi tiết hơn ở các bức hình thiếu sáng. Trong khi đó ống kính góc rộng có thể thu được nhiều sáng hơn, lên đến 47% giúp chất lượng bức ảnh, video được cải thiện hơn." +
                    "<br><br>Cụm camera được trang bị tính năng ổn định hình ảnh quang học cùng cảm biến mới, nhờ đó bức hình chụp mang lại khả năng ổn định." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/223602/Slider/vi-vn-iphone-13-up-2.jpeg") +
                    "Con chip Apple A15 Bionic siêu mạnh được sản xuất trên quy trình 5 nm giúp iPhone 13 đạt hiệu năng ấn tượng, với CPU nhanh hơn 50%, GPU nhanh hơn 30% so với các đối thủ trong cùng phân khúc.\r\n\r\n" +
                    "<br><br>" +
                    "Nhờ hiệu năng được cải tiến, người dùng có được những trải nghiệm tốt hơn trên điện thoại khi dùng các ứng dụng chỉnh sửa ảnh hay chiến các tựa game đồ họa cao mượt mà." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/223602/Slider/vi-vn-iphone-13-up-3.jpg") +
                    "iPhone 13 trang bị bộ nhớ trong 128 GB dung lượng lý tưởng cho phép bạn thỏa thích lưu trữ mọi nội dung theo ý muốn mà không lo nhanh đầy bộ nhớ." +
                    "<br><br>" +
                    "Mạng 5G được cải thiện chất lượng với nhiều băng tần hơn, với 5G giúp điện thoại xem trực tuyến hay tải xuống các ứng dụng và tài liệu đều đạt tốc độ nhanh chóng. Không chỉ vậy, siêu phẩm mới này còn có chế độ dữ liệu thông minh, tự động phát hiện và giảm tải tốc độ mạng để tiết kiệm năng lượng khi không cần dùng tốc độ cao." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/223602/Slider/vi-vn-iphone-13-up-11.jpeg") +
                    "Nhờ có công nghệ Super Retina XDR giúp cho máy đạt độ sáng 800 nits, tối đa lên đến 1200 nits cùng dải màu rộng P3, tỷ lệ tương phản lớn giúp ổn định tốt màu sắc và chất lượng hình ảnh hiển thị trong nhiều điều kiện sáng khác nhau, kể cả môi trường nắng gắt hay ánh sáng chói." +
                    "<br><br>" +
                    "Cụm camera kép phía sau trên iPhone 13 đều sở hữu độ phân giải 12 MP, camera chính giúp thu được nhiều ánh sáng hơn, tăng khả năng thu sáng lên đến 47% nên chất lượng ảnh chụp cũng cải thiện hơn so với bản tiền nhiệm. Điện thoại có camera góc siêu rộng cho góc nhìn 120 độ giúp thu được nhiều chi tiết hơn, dễ dàng ghi lại những khung cảnh núi non hùng vĩ, ảnh chụp nhóm đông người." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/223602/Slider/vi-vn-iphone-13-up-15.jpeg") +
                    "Camera trước vẫn nằm trong tai thỏ, độ phân giải cũng đạt 12 MP với các công nghệ chụp ảnh chuyên nghiệp như hiệu ứng bokeh, chế độ điện ảnh, Animoji và Memoji để bạn tự tin thể hiện mình trước ống kính, không lo lắng che giấu khuyết điểm.",
                    Hot = 1,
                    Photo = "iPhone13128GB.webp",
                    Price = 18990000,
                    DiscountID = 1,
                    Amount = 50
                },
                new Products
                {
                    ID = 3,
                    Name = "iPhone 11 64GB I Chính hãng VN/A",
                    CategoryID = 1,
                    Decription = "<b>iPhone 11</b> sở hữu hiệu năng khá mạnh mẽ, ổn định trong thời gian dài nhờ được trang bị chipset A13 Bionic. Màn hình LCD 6.1 inch sắc nét cùng chất lượng hiển thị Full HD của máy cho trải nghiệm hình ảnh mượt mà và có độ tương phản cao. Hệ thống camera hiện đại được tích hợp những tính năng công nghệ mới kết hợp với viên Pin dung lượng 3110mAh, giúp nâng cao trải nghiệm của người dùng.",
                    Content = "<br><br> " + comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/153856/Slider/vi-vn-iphone-11-up-3.jpeg") +
                    "<br><br>" +
                    "Ở mức cấu hình trên giúp điện thoại chơi game tốt với các tựa game phổ biến hiện nay một cách mượt mà, ổn định. Mọi thao tác trên iPhone mới cũng cho tốc độ phản hồi nhanh mà bạn gần như sẽ không cảm nhận được sự giật lag cho dù có sử dụng trong một thời gian dài." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/153856/Slider/vi-vn-iphone-11-up-5.jpg") +
                    "iPhone 13 có một sự thay đổi lớn về camera so với trên iPhone 12 Series. Cụ thể, iPhone có thể được trang bị ống kính siêu rộng mới giúp máy hiển thị được nhiều chi tiết hơn ở các bức hình thiếu sáng. Trong khi đó ống kính góc rộng có thể thu được nhiều sáng hơn, lên đến 47% giúp chất lượng bức ảnh, video được cải thiện hơn." +
                    "Dù đã ra mắt được hơn 3 năm nhưng iPhone 11 vẫn là một trong những thiết bị smartphone đáng mua nhất ở thời điểm hiện tại. Hiệu năng, khả năng tính toán cùng chất lượng hiển thị của màn hình vẫn vô cùng sắc nét và người tiêu dùng đánh giá rất cao. Dưới đây là những thông số cấu hình chi tiết của iPhone thế hệ thứ 11 mà bạn có thể tham khảo." +
                    "Thiết kế bên ngoài của iPhone 11 được kế thừa và phát triển từ phiên bản tiền nhiệm đã được ra mắt trước đó là iPhone XR. Cụm camera của máy vẫn giữ nguyên thiết kế theo chiều dọc nhưng phần mô-đun chứa camera được mở rộng hơn đem tới những trải nghiệm hoàn toàn mới lạ cho người dùng. Phần viền thân máy và các góc cạnh của iPhone 11 được thiết kế dạng cong bo mềm mại." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/153856/Slider/vi-vn-iphone-11-up-8.jpg") +
                    "Đây là một điều được xem là bước ngoặt bởi những chiếc smartphone Android có nhiều camera hiện nay sẽ thường bị sai lệch về màu sắc khi chuyển đổi qua lại giữa các ống kính gây cảm giác khá khó chịu cho người dùng." +
                    "<br><br>" +
                    "Theo trải nghiệm thì tính năng này hoạt động rất hiệu quả đặc biệt trong những môi trường cực kỳ thiếu sáng.\r\n\r\n" +
                    "<br><br>" +
                    "Kích hoạt chế độ chụp đêm sẽ do iPhone tự quyết định việc của bạn chỉ cần đưa máy lên và chụp, rất đơn giản." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/153856/Slider/vi-vn-iphone-11-up-11.jpeg") +
                    "Camera trước cũng có một tính năng thông minh, khi bạn xoay ngang điện thoại nó sẽ tự kích hoạt chế độ selfie góc rộng để bạn có thể chụp với nhiều người hơn." +
                    "<br><br>" +
                    "Ngoài ra Apple cũng giới thiệu tính năng quay video slow motion dành cho camera trước, điều mà Apple chưa từng trang bị cho những chiếc iPhone trước đây." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/153856/Slider/vi-vn-iphone-11-up-14.jpeg") +
                    "Kết hợp với trọng lượng chỉ vỏn vẹn 194 gram cùng kích thước sản phẩm lần lượt là 150.9 x 75.7 x 8.3 mm, iPhone thế hệ thứ 11 sẽ mang tới cho bạn cảm giác cầm nắm cực kỳ thoải mái. Bạn có thể thoải mái sử dụng sản phẩm cả ngày dài mà không cảm thấy khó chịu hay đau mỏi phần cổ tay. Các phím, nút điều chỉnh âm lượng của thiết bị được bố trí quanh viền thân máy, thể hiện sự hoàn hảo trong thiết kế của sản phẩm.",
                    Hot = 1,
                    Photo = "iPhone1164GB.webp",
                    Price = 11990000,
                    DiscountID = 1,
                    Amount = 50
                },
                new Products
                {
                    ID = 4,
                    Name = "iPhone 12 Pro 256GB I Chính hãng VN/A",
                    CategoryID = 1,
                    Decription = "Mẫu iPhone 2020 mới nhất của Apple được thiết kế khung viền vuông sang trọng được nhiều người dùng yêu thích. Trong đó, phiên bản <b>iPhone 12 Pro 256GB chính hãng VNA</b> hứa hẹn là một trong những sự lựa chọn lý tưởng.",
                    Content = "<br><br> " + 
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/228738/iphone-12-pro-256gb-130021-030015.jpg") +
                      "<br><br>" +
                      "iPhone 12 Pro 256GB chính hãng VNA được thiết kế với khung viền vuông vắn – sang trọng. Thiết kế mang hơi hướng của các sản phẩm iPhone 4, 5 trước đó. Máy hỗ trợ kết nối 4G, mang đến tốc độ lướt web nhanh chóng." +
                      "<br><br>" +
                      comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/228738/iphone-12-pro-256gb-294420-104406.jpg") +
                       "<br><br>" +
                       "Đúng như tên gọi Pro, Apple sử dụng chất liệu thép cao cấp cho phần khung viền thay vì nhôm như trên điện thoại iPhone 12 và iPhone 12 Mini, mang đến độ bền vượt trội và diện mạo bóng bẩy sang trọng hơn." +
                       "<br><br>" +
                       comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/228738/Slider/iphone-12-pro-256gb-281120-1213150.jpg") +
                       "Máy trang bị tấm nền Super Retina XDR OLED cho hiển thị màu sắc vô cùng chuẩn xác với không gian màu P3, hỗ trợ HDR, True Tone, màu đen sâu tiết kiệm pin hơn, độ sáng cao 800 nits ấn tượng ở mọi góc nhìn." +
                       "<br><br>" +
                       "iPhone 12 Pro vẫn có phần khuyết tai thỏ khá lớn do chứa cụm cảm biến Face ID nhận diện khuôn mặt. Tuy nhiên, điều này không phải là trở ngại, các ứng dụng cũng đã tối ưu tốt để không bi ảnh hưởng bởi tai thỏ." +
                       "<br><br>" +
                       comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/228738/Slider/iphone-12-pro-256gb-281120-1213215.jpg") +
                       "Đặc biệt, màn hình trên iPhone 12 Pro còn là màn hình cứng và bền nhất trên các dòng iPhone từ trước đến nay, khi phủ một lớp gốm ceramic giúp màn hình hiển thị của bạn khỏi những vết trầy xước đáng kể cũng như mang lại độ bền cao, tốt hơn gấp 4 lần thông thường mỗi khi rơi vỡ." +
                       "<br><br>" +
                       "iPhone 12 Pro trang bị vi xử lý A14 Bionic hoạt động trên tiến trình 5 nm tối tân nhất, chứa đến 11.8 ngàn tỷ bóng bán dẫn. Thật không ngoa khi Apple tuyên bố đây là con chip mạnh mẽ nhất được trang bị trên smartphone ở thời điểm hiện tại (10/2020)." +
                       "<br><br>" +
                       comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/228738/Slider/iphone-12-pro-256gb-281120-12133514.jpg") +
                       "Có 6 nhân CPU với 2 nhân tốc độ cao và 4 nhân tiết kiệm điện, A14 Bionic mạnh hơn đến 40% so với A13 trước đây. Kết hợp với nhân GPU cho các tác vụ xử lý đồ họa như chơi game, xử lý video trở nên nhanh và siêu mượt mà." +
                       "<br><br>" +
                      "Phiên bản chính hãng VNA là phiên bản được sản xuất dựa trên thói quen sử dụng của người dùng Việt. iPhone 12 Pro 256GB chính hãng VNA sẽ được hưởng bảo hành chính hãng của Apple.",
                    Hot = 1,
                    Photo = "iPhone12Pro256GB.webp",
                    Price = 11990000,
                    DiscountID = 1,
                    Amount = 50
                },
                new Products
                {
                    ID = 5,
                    Name = "iPhone SE 2022 128GB | Chính hãng VN/A",
                    CategoryID = 1,
                    Decription = "Được trang bị con chip Apple A15 Bionic mới nhất cho điện thoại mang đến một hiệu năng mạnh mẽ. Nó sẽ có thể xử lý mọi tác vụ bất kể là nặng hay nhẹ một cách mượt mà." +
                      "<br><br>" +
                      comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/274158/iphone-se-128gb-2022.jpg") + "<br>" +
                      "Cho tới năm 2023 thì hãng vẫn còn tiếp tục sử dụng con chip Apple A15 Bionic lên trên điện thoại iPhone 14, điều này càng thêm minh chứng rằng đây là con chip có hiệu năng khủng để có thể xử lý tốt nhiều tác vụ kể cả nâng cao.",
                    Content = "<br><br>" +
                      "Được nâng cấp đáng kể thời lượng pin từ thế hệ tiền nhiệm khi bạn có thể xem phim liên tục 15 tiếng đồng hồ và có cả sạc nhanh 20 W giúp bạn có thể rút ngắn thời gian sạc." +
                      "<br><br>" +
                      comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/274158/iphone-se-128gb-2022-2.jpg")+
                      "<br><br>" +
                      "Mang trên mình camera sau 12 MP và camera trước 7 MP có lẽ nhiều người sẽ cho rằng nó khá khiêm tốn khi hầu hết các điện thoại thời nay đều có độ phân giải camera chính khá cao. Nhưng bạn đừng quá lo lắng, thuật toán chụp ảnh trên iPhone rất tuyệt vời, nó sẽ cho bạn những tấm ảnh tuyệt vời nhất. " +
                      "<br><br>" +
                      comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/274158/Slider/iphone-se-128gb-2022637858889715407654.jpg")+
                      "Nếu như nhu cầu chụp ảnh của bạn đòi hỏi chất lượng cao hơn thì điện thoại iPhone 14 Pro Max có thể sẽ là lựa chọn phù hợp hơn, máy sở hữu cụm 3 camera trong đó cảm biến chính có độ phân giải lên tới 48 MP." +
                      "<br><br>" +
                      "Theo mình thấy, vì đây chỉ là một chiếc điện thoại được cho là nằm ở phân khúc tầm trung của nhà Apple nhưng vẫn được trang bị khá nhiều công nghệ hiện đại, mang đến cho bạn một trải nghiệm mượt mà, ấn tượng." +
                      "<br><br>" +
                      comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/274158/Slider/iphone-se-128gb-2022637858889722867513.jpg") +
                      "Theo mình thấy, vì đây chỉ là một chiếc điện thoại được cho là nằm ở phân khúc tầm trung của nhà Apple nhưng vẫn được trang bị khá nhiều công nghệ hiện đại, mang đến cho bạn một trải nghiệm mượt mà, ấn tượng.",
                    Hot = 1,
                    Photo = "iPhoneSE2022128GB.webp",
                    Price = 11990000,
                    DiscountID = 1,
                    Amount = 50
                },
                new Products
                {
                    ID = 6,
                    Name = "iPhone XR 128GB I Chính hãng VN/A",
                    CategoryID = 1,
                    Decription = "<b>iPhone XR 128GB - Smartphone thiết kế tinh tế, nhiều màu sắc</b>" +
                       "<br><br>" +
                       "Bạn đang cần một chiếc iPhone thế hệ mới, với những tính năng mới nhất, thiết kế tinh tế, cấu hình mạnh nhất, nhưng với một mức giá tốt hơn rất nhiều? Hãy để tâm đến iPhone XR 128GB. Đây là một thiết bị iPhone không thể bỏ qua với những nhu cầu thiết yếu trên.",
                    Content = "<br><br>" +
                       "<b>Mua iPhone XR 128GB chính hãng VN/A có những đặc quyền gì so với iPhone khác?</b>" +
                       "<br><br>" +
                       "Hiện tại có rất nhiều loại iPhone đang có mặt trên thị trường: từ xách tay Mỹ, Hàn, Nhật, cho đến VN/A, song song với đó là các loại iPhone CPO, Refurbished với những mức giá khác nhau. Trong số đó, iPhone VN/A thường có một mức giá cao hơn hẳn so với những thiết bị còn lại. Tuy nhiên, mức giá cao cũng đi kèm với nhiều đặc quyền: vậy đâu là đặc quyền khi sử dụng iPhone chính hãng VN/A?" +
                       comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/191483/iphone-xr-128gb-a12.jpg") +
                       "<br><br>" +
                       "Với iPhone XR 128GB chính hãng VN/A, bạn sẽ sở hữu đến 128GB bộ nhớ trong. Đây là dung lượng bộ nhớ dư dả cho đa số các nhu cầu lưu trữ ứng dụng, hình ảnh, cũng như phim ảnh. Từ đó bạn có thể an tâm sử dụng máy trong một thời gian dài hơn trước khi cần mua thêm một bộ nhớ gắn ngoài, hoặc backup lưu lại dữ liệu trên máy. Nếu nhu cầu lưu trữ thấp hơn thì có thể tham khảo điện thoại iPhone XR 64GB." +
                       "<br><br>" +
                       "Apple A12 được tích hợp trí tuệ thông minh nhân tạo, mọi phản hồi trên máy đều nhanh chóng và gần như là ngay lập tức, kể cả khi bạn chơi game hay thao tác bình thường." +
                       "<br><br>" +
                        comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/191483/Slider/-iphone-xr-thumbvideo.jpg") +
                       "Hơn nữa với AI trên Apple A12, iPhone Xr có thể ghi nhớ được thao tác hằng ngày của bạn để hoàn thiện và hỗ trợ người dùng tốt hơn." +
                       "<br><br>" +
                       "Thực tế khi chơi game trên iPhone Xr, môi trường và hiệu ứng trong game rất thật. Hơn nữa trên chiếc iPhone còn hỗ trợ thực tế tăng cường: Chơi game thực tế ảo với nhiều người cùng chơi, trải nghiệm cùng 1 môi trường với nhau." +
                       "<br><br>" +
                       comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/191483/Slider/-iphone-xr-hieunang.jpg") +
                       "Trước đây để trải nghiệm tối đa âm thanh thì tai nghe là thiết bị không thể thiếu. Nhưng với điện thoại iPhone thế hệ mới, công nghệ âm thanh đa chiều từ loa sẽ giúp bạn hoà vào âm nhạc cũng như các bộ phim thú vị hay chơi game hào hứng nhất." +
                       "<br><br>" +
                       "Nếu ai đó khẳng định chỉ camera kép mới xoá phông thì đó là một sai lầm. iPhone Xr có khả năng tạo hiệu ứng bokeh tuyệt đỉnh, làm nổi bật chân dung người chụp mà hình ảnh vẫn rất sắc nét, chi tiết.\r\n\r\n" +
                       "<br><br>" +
                        comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/191483/Slider/vi-vn-iphone-xr-loa.jpg") +
                       "Song song với Apple A12 mạnh mẽ cùng dung lượng bộ nhớ trong ấn tượng, iPhone XR 128GB chính hãng VN/A còn sở hữu 3GB RAM. Bộ nhớ RAM này sẽ đảm bảo máy hoạt động mượt mà trong mọi thao tác đa nhiệm, không gặp hiện tượng khựng hay đứng khung hình khi chuyển cảnh. Đi cùng với iOS 12 tối ưu cực kỳ tốt, đa dạng về tính năng, iPhone XR chắc chắn sẽ là một trong những thiết bị smartphone có hiệu năng mạnh mẽ nhất không chỉ cuối năm 2018 mà còn là trong năm 2019.",
                    Hot = 1,
                    Photo = "iPhoneXR128GB.webp",
                    Price = 16990000,
                    DiscountID = 1,
                    Amount = 50
                },
                new Products
                {
                    ID = 7,
                    Name = "iPhone 13 Pro Max 128GB | Chính hãng VN/A",
                    CategoryID = 1,
                    Decription = "iPhone 12 ra mắt cách đây chưa lâu, thì những tin đồn mới nhất về iPhone 13 Pro Max đã khiến bao tín đồ công nghệ ngóng chờ. Cụm camera được nâng cấp, màu sắc mới, đặc biệt là màn hình 120Hz với phần notch được làm nhỏ gọn hơn chính là những điểm làm cho thu hút mọi sự chú ý trong năm nay.",
                    Content = "<br><br>" +
                       "Dòng iPhone 12 được Apple áp dụng ngôn ngữ thiết kế tương tự iPhone 12 năm ngoái với phần cạnh viền máy được dát phẳng sang trọng cùng bốn góc được làm bo cong nhẹ, đây có thể được xem là một thiết kế hoài cổ từ dòng iPhone 5 trước đó. Vì thế mà iPhone 13 Pro Max nói riêng, cũng như dòng iPhone 13 nói chung, cũng sẽ đi theo ngôn ngữ thiết kế này." +
                       "<br><br>" +
                       comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/230529/iphone-13-pro-max-2.jpg") +
                      "<br><br>" +
                       "Điểm thay đổi lớn trên 13 Pro Max có thể là phần nhô của cụm camera. Trong khi đó mặt trước của thiết bị được phủ một lớp Ceramic Shield, loại vật liệu cứng hơn bất kỳ loại kính điện thoại thông minh nào hiện có trên thị trường, giúp bảo vệ màn hình iPhone hiệu quả." +
                      "<br><br>" +
                        comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/230529/iphone-13-pro-max-1.jpg") +
                       "Xét về chất liệu, iPhone 13 Pro Max vẫn áp dụng chất liệu thép không gỉ như thế hệ trước đó. Mặt này cũng được phủ một lớp kính mờ giúp hạn chế bám bụi bẩn và vân tay. Ngoài ra, điện thoại cũng sẽ đảm bảo được khả năng chống bụi / nước chuẩn IP68." +
                       "<br><br>" +
                       "Với iPhone 13 Pro Max phần tai thỏ đã được thu gọn lại 20% so với thế hệ trước, không chỉ giải phóng nhiều không gian hiển thị hơn mà còn giúp mặt trước chiếc điện thoại trở nên hấp dẫn hơn mà vẫn đảm bảo được hoạt động của các cảm biến." +
                       "<br><br>" +
                       comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/230529/Slider/vi-vn-iphone-13-pro-max-slider-tong-quan.jpg") +
                       "Điểm thay đổi dễ dàng nhận biết trên iPhone 13 Pro Max chính là kích thước của cảm biến camera sau được làm to hơn và để tăng độ nhận diện cho sản phẩm mới thì Apple cũng đã bổ sung một tùy chọn màu sắc Sierra Blue (màu xanh dương nhạt hơn so với Pacific Blue của iPhone 12 Pro Max)." +
                       "<br><br>" +
                       "Máy vẫn tiếp tục sử dụng khung viền thép cao cấp cho khả năng chống trầy xước và va đập một cách vượt trội, kết hợp với khả năng kháng bụi, nước chuẩn IP68." +
                       "<br><br>" +
                        comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/230529/Slider/iphone-13-pro-max-slider-ios15-1020x570.jpg") +
                       "iPhone Pro Max năm nay đã được nâng cấp lên tần số quét 120 Hz, mọi thao tác chuyển cảnh khi lướt ngón tay trên màn hình trở nên mượt mà hơn đồng thời hiệu ứng thị giác khi chúng ta chơi game hoặc xem video cũng cực kỳ mãn nhãn." +
                       "<br><br>" +
                       "Về màu sắc, chiếc iPhone 13 phiên bản Pro Max sẽ được ra mắt với nhiều tùy chọn màu sắc khác nhau. Trong đó gồm một số màu nổi bật như: vàng, bạc, xanh, đen,...",
                    Hot = 1,
                    Photo = "iPhone13ProMax128GB.webp",
                    Price = 28990000,
                    DiscountID = 1,
                    Amount = 50
                },
                new Products
                {
                    ID = 8,
                    Name = "iPhone 14 Pro 128GB | Chính hãng VN/A",
                    CategoryID = 1,
                    Decription = "Ngoài ba phiên bản gồm iPhone 14 thường, bản Pro và Pro Max, năm nay Apple dự kiến sẽ cho ra thêm một phiên bản mới mang tên iPhone 14 Plus. Được tích hợp nhiều cải tiến nổi trội về phần cứng, iPhone 14 Plus hứa hẹn sẽ là siêu phẩm khẳng định đẳng cấp smartphone hiện đại.",
                    Content = "<br><br>" +
                        "Dựa trên các rò rỉ nguyên mẫu gần đây, chúng ta sẽ thấy iPhone 14 Plus (cũng như toàn bộ series điện thoại iPhone 14) mang ngoại hình tương đồng với dòng iPhone 13 trước đó. Cụ thể, cạnh viền của máy sẽ được dát phẳng vuông vức và hoàn thiện từ thép không gỉ bền vững. Toàn bộ thân iPhone 14 Plus đều đạt chuẩn chống bụi và chống nước IP68, củng cố độ bền cao cấp cho thiết bị." +
                        "<br><br>" +
                        comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/247508/Slider/iphone-14-pro-tong-quan-1020x570.jpg") +
                        "Một điều chú ý ở iPhone 14 Plus đó là chiếc máy được cho rằng sẽ lấp vào khoảng trống giữa bản Pro và Pro Max. Vì vậy kích thước tổng thể của iPhone 14 Plus lớn hơn so với iPhone 14 bản chuẩn. Sự bổ sung của iPhone 14 Plus được cho là thay thế phiên bản Mini." +
                       "<br><br>" +
                        "Phiên bản 5 màu sắc khác nhau mang đến cho người dùng nhiều sự lựa chọn: Blue, Purple, Starlight, Mid Night và Product Red." +
                        "<br><br>" +
                        comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/247508/Slider/vi-vn-iphone-14-pro-up-4.jpg") +
                        "Về công nghệ màn hình, iPhone 14 Plus sử dụng tấm nền Super Retina XDR OLED mang lại độ tương phản màu sắc ấn tượng. Cùng với đó, độ phân giải 2778 x 1284 pixels cho hình ảnh và màu sắc chi tiết, độ chính xác cao, mang lại cho người dùng cảm giác chân thực và sắc nét." +
                        "<br><br>" +
                        "Đến với thiết kế của iPhone 14 Pro năm nay, hãng vẫn giữ lại nét đặc trưng vốn có từ các đời trước, vẫn mang trong mình ngoại hình vuông vức với các cạnh và mặt lưng vát phẳng. Hiện tại thị hiếu của người dùng về kiểu thiết kế này vẫn đang rất cao, vậy nên theo mình thấy thì đây vẫn sẽ là chiếc điện thoại bắt trend cho trong nhiều năm tiếp theo." +
                        "<br><br>" +
                         comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/247508/Slider/vi-vn-iphone-14-pro-up-8.jpg") +
                        "Bộ khung điện thoại được làm từ chất liệu thép không gỉ và hoàn thiện theo kiểu bóng nhoáng, điều này giúp thiết bị trở nên bền bỉ cũng như làm tăng thêm phần sang trọng. Mỗi khi nghiêng máy qua nhiều góc độ khác nhau mình thấy phần khung này trở nên cuốn hút hơn nhờ khả năng phản quang vô cùng thú vị." +
                        "<br><br>" +
                        "Sau một thời gian sử dụng, mình thấy bộ khung này khá là dễ bám dấu vân tay, sử dụng điện thoại khi tay có mồ hôi cũng sẽ trở nên khó khăn hơn đôi chút bởi máy lúc này khá trơn. Để khắc phục được hai việc trên thì người dùng cũng có thể dùng thêm ốp lưng để đảm bảo quá trình sử dụng được thuận tiện nhất." +
                        "<br><br>" +
                         comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/247508/Slider/vi-vn-iphone-14-pro-up-11.jpg") +
                        "Về phần mặt lưng, vật liệu cấu tạo chính sẽ là kính cường lực và được hoàn thiện nhám để cho ra cái nhìn cao cấp hơn, mình cảm thấy cách làm nhám này cũng đã khắc phục được đáng kể tình trạng bám dấu vân tay so với mặt lưng bóng trên iPhone 14.\r\n\r\n" +
                        "<br><br>" +
                        "Không chỉ vậy, thiết bị còn được tích hợp công nghệ True Tone hỗ trợ điều chỉnh ánh sáng theo môi trường, Dolby Vision (một tính năng phổ biến trong ngành điện ảnh) tối ưu chất lượng hình ảnh, HDR và Haptic Touch.",
                    Hot = 1,
                    Photo = "iPhone14 Plus128GB.webp",
                    Price = 24990000,
                    DiscountID = 1,
                    Amount = 50
                },
                new Products
                {
                    ID = 9,
                    Name = "iPhone 14 128GB | Chính hãng VN/A",
                    CategoryID = 1,
                    Decription = "iPhone 14  có sự cải thiện lớn màn hình so với iPhone 13 . Sự khác biệt giữ phiên bản iPhone 14  256GB và 128GB tiêu chuẩn chỉ là bộ nhớ trong. Dưới đây là một số cải tiến nổi bật trên iPhone 14 Pro mà có thể bạn chưa biết!",
                    Content = "  < br >< br > " +
                        "Kích thước màn hình iPhone 14  vẫn là 6.1 inch tuy nhiên phần “tai thỏ” đã được thay thế bằng một đường cắt hình viên thuốc. Apple gọi đây là Dynamic Island - nơi chứa camera Face ID và một đường cắt hình tròn thứ hai cho camera trước." +
                         "<br><br>" +
                        comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/240259/Slider/vi-vn-iphone-14-up-2.jpeg") +
                        "Ngoài ra, iPhone 14 Pro có tính năng màn hình luôn bật hoạt động (Always-on Display) với tiện ích màn hình khóa mới trên iOS 16. Người dùng có thể xem các thông tin như lời nhắc, sự kiện lịch và thời tiết mà không cần bật máy lên để xem. Thậm chí, có một trạng thái ngủ cho hình nền, trạng thái này sẽ làm tối hình nền để sử dụng ít pin hơn." +
                        "<br><br>" +
                        "Phiên bản 5 màu sắc khác nhau mang đến cho người dùng nhiều sự lựa chọn: Blue, Purple, Starlight, Mid Night và Product Red." +
                        "<br><br>" +
                        comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/240259/Slider/vi-vn-iphone-14-up-7.jpg") +
                        "Về công nghệ màn hình, iPhone 14 Plus sử dụng tấm nền Super Retina XDR OLED mang lại độ tương phản màu sắc ấn tượng. Cùng với đó, độ phân giải 2778 x 1284 pixels cho hình ảnh và màu sắc chi tiết, độ chính xác cao, mang lại cho người dùng cảm giác chân thực và sắc nét." +
                        "<br><br>" +
                        "iPhone 14 có kích thước chiều ngang là 71.5 mm nên máy có thể dễ dàng nằm gọn trong lòng bàn tay mỗi khi sử dụng, điều này làm cho điện thoại trở nên phù hợp hơn với nhiều đối tượng người dùng hơn, kể cả những bạn nữ có bàn tay nhỏ nhắn.\r\n\r\n" +
                        "<br><br>" +
                        comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/240259/Slider/vi-vn-iphone-14-up-8.jpg") +
                        "Mặt lưng của điện thoại được thiết kế từ kính cường lực và hoàn thiện theo kiểu nhẵn bóng, theo mình thì cách làm này giúp cho iPhone 14 trông cuốn hút hơn, bên cạnh đó nó máy cũng khá bền bỉ có thể mang lại khả năng chống chịu các vết xước được tốt hơn." +
                        "<br><br>" +
                        "Có một lưu ý nhỏ ở phần thiết kế là máy khá dễ bám dấu vân tay, điều này càng thêm lộ rõ ở những phiên bản có màu đậm như đen và đỏ, còn ở các phiên bản màu sáng như xanh dương, trắng và tím nhạt thì điều này cũng được cải thiện." +
                        "<br><br>" +
                         comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/240259/Slider/vi-vn-iphone-14-up-10.jpg") +
                        "Năm nay Apple cho ra mắt hai phiên bản có màu mới dành cho iPhone 14 là tím nhạt và xanh dương, theo mình thấy thì màu xanh này có màu dịu nhẹ hơn so với iPhone 13. Vậy nên nhờ màu sắc mà mình có thể dễ dàng phân biệt giữa hai dòng điện thoại, nếu muốn mọi người xung quanh biết được rằng bạn đang sở hữu iPhone 14 thì hai màu sắc này sẽ là sự lựa chọn rất phù hợp.\r\n\r\n" +
                        "<br><br>" +
                        "Dòng sản phẩm iPhone 14 gây bất ngờ khi trang bị khả năng kết nối vệ tinh. Tính năng này giúp cho điện thoại có thể hỗ trợ định vị người dùng thông qua các mạng vệ tinh trong những trường hợp khẩn cấp mà các tháp di động thông thường không thể tiếp cận được.. Bên cạnh đó, những tin nhắn được gửi từ kết nối vệ tinh cũng sẽ xuất hiện ở ứng dụng tin nhắn và có màu xám.",
                    Hot = 1,
                    Photo = "iPhone 14 128GB.webp",
                    Price = 19090000,
                    DiscountID = 1,
                    Amount = 50
                },
                // Add SamSung
                new Products
                {
                    ID = 10,
                    Name = "Samsung Galaxy S23 Ultra 256GB",
                    CategoryID = 2,
                    Decription = "<b style='color:red'>Samsung Galaxy S23 Ultra </b>là điện thoại cao cấp của hãng điện thoại Samsung được ra mắt vào đầu năm 2023. Điện thoại Samsung S23 series mới này sở hữu camera độ phân giải 200MP ấn tượng cùng một khung viền vuông vức sang trọng. Cấu hình máy cũng là" +
                    " một điểm nổi bật với con chip Snapdragon 8 Gen 2 mạnh mẽ, bộ nhớ RAM 8GB mang lại hiệu suất xử lý vượt trội.",
                    Content = "Sau sự đổ bộ thành công của <b>Samsung Galaxy S22</b> những chiếc điện thoại dòng Flagship tiếp theo - Điện thoại Samsung Galaxy S23 Ultra là đối tượng được Samfans hết mực săn đón. Kiểu dáng thanh lịch sang chảnh " +
                    "kết hợp với những bước đột phá trong công nghệ đã kiến tạo nên siêu phẩm Flagship nhà Samsung." +
                    "<br>" +
                     "<br>" +
                     comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/249948/samsung-galaxy-s23-ultra-150423-020403.jpg") +
                    "Tiếp nối thiết kế từ những chiếc Samsung Galaxy S22 Ultra, những chiếc Galaxy S23 Ultra mang dáng vẻ thanh mảnh với những đường nét được gọt giũa chỉnh chu và cực kỳ tinh tế. Với màn hình tràn viền, tỷ lệ màn hình trên thân máy hơn 90%" +
                    " những chiếc điện thoại S23 Ultra hứa hẹn mang đến một thiết kế thời thượng thu hút mọi ánh nhìn." +
                    "<br>" +
                     "<br>" +
                    "Vẫn là mặt lưng nguyên khối cùng cụm camera không viền được đặt ở góc trái trên cùng logo Samsung quen thuộc nằm góc dưới mặt lưng tạo cảm giác đơn giản nhưng không kém phần nổi bật cho thiết kế. Thanh lịch nhưng đặc biệt có sức hút, đơn giản mà toát lên sự cao cấp, những chiếc Samsung Galaxy S23 Ultra chắc chắn là sự lựa chọn hoàn hảo khi bình chọn những thiết kế đỉnh cao trong năm 2022." +
                    "<br>" +
                     "<br>" +
                     comonFunction.ImageTag("images.fpt.shop/unsafe/filters:quality(90)/fptshop.com.vn/Uploads/images/2015/Tin-Tuc/02/Thiet-ke-Samsung-Galaxy-S23-Ultra-1(1).jpg") +
                    "Diện mạo của những chiếc Samsung Galaxy S23 Ultra có khả năng thu hút bất tận với chuỗi màu sắc đa dạng mà không kém phần thanh lịch, dòng điện thoại này ngay lập tức tạo nên định nghĩa vẻ đẹp công nghệ mới cho người dùng ngay khi chạm mắt." +
                    "<br>" +
                    "<br>" +
                    "Về màu sắc, năm nay Samsung cũng đã cho ra các phiên bản màu như: Tím, kem, xanh và đen. Nhìn chung thì đây là những màu sắc cực kỳ sang trọng và lịch lãm, phù hợp cho các bạn trẻ năng động, mạnh mẽ và đặc biệt là những khách hàng đang là doanh nhân bởi ngoại hình đẳng cấp và thanh lịch." +
                    "<br>" +
                    "<br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/249948/Slider/tong-quan-s23-ultra-1020x570.jpg")+
                    "Bộ khung này được làm theo kiểu bóng loáng giúp máy có thêm một điểm nhấn đầy nổi bật về thiết kế. Cảm giác khi sờ vào bộ khung như được phủ một lớp mạ bóng xung quanh, vì thế đây sẽ không phải là vị trí dễ xước như một bộ phận người người dùng hoài nghi. " +
                    "<br>" +
                    "<br>" +
                    "Tại thời điểm ra mắt sản phẩm, Galaxy S23 Ultra có thể xem là chiếc điện thoại Android sở hữu hiệu năng mạnh mẽ bậc nhất thị trường. Điều này là do Samsung đã trang bị con chip Snapdragon 8 Gen 2 tân tiến được nhà Qualcomm tối ưu riêng biệt cho dòng sản phẩm Galaxy S series, mang lại hiệu năng vượt trội so với Snapdragon 8 Gen 2 thông thường." +
                    "<br>" +
                    "<br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/249948/Slider/vi-vn-samsung-galaxy-s23-ultra-9.jpg") +
                    "Bên cạnh đó, Samsung còn sử dụng vật liệu tái chế thân thiện với môi trường trên S23 Ultra. Theo đó các lớp kính phủ đến màu sơn đều là những điểm nhấn độc đáo trên mẫu flagship này.",
                    Hot = 1,
                    Photo = "SamsungGalaxyS23Ultra256GB.webp",
                    Price = 31990000,
                    DiscountID = 1,
                    Amount = 50
                },
                new Products
                {
                    ID = 11,
                    Name = "Samsung Galaxy S22 Ultra (8GB - 128GB)",
                    CategoryID = 2,
                    Decription = "Trước khi chính thức ra mắt cộng đồng những chiếc điện thoại<b> Samsung S22 Series </b.đã có thời gian được thai nghén khá dài để đảm bảo có những tính năng thực sự vượt trội so với phiên bản tiền nhiệm. Để có thể hình dung rõ ràng ta xét đến 2 mẫu Samsung S22 Ultra và S21 Ulta xem dòng flagship mới nhà Samsung có những nâng cấp nổi trội nào nhé!",
                    Content = "Samsung Galaxy S22 Ultra đi theo ngôn ngữ thiết kế nguyên khối -" +
                    " kính cao cấp và sang trọng, vốn đã làm nên sự thành công của model tiền nhiệm. Chiếc máy có thiết kế mặt lưng đơn sắc tối giản nhưng không kém phần tinh tế, và màn hình tràn viền bao phủ gần như trọn mặt trước, tạo nên trải nghiệm quan sát rộng rãi trên một thiết bị di động nhỏ gọn vừa tay cầm" +
                    "<br>" +
                    "<br>" +
                    "Độ bền của máy được đảm bảo tối ưu không chỉ qua lớp vỏ nhôm nguyên khối Amor đánh bóng, mà còn qua kính cường " +
                    "lực Corning Gorilla Glass Victus+ bao phủ hai mặt trước và sau. Khung nhôm và kính hoạt động như bộ giáp bảo vệ điện thoại an toàn. Chiếc máy còn có khả năng chống bụi / nước đạt chuẩn IP68 giúp người dùng luôn an tâm khi dùng máy trong những điều kiện môi trường khác nhau." +
                    "<br>" +
                    comonFunction.ImageTag("cdn2.cellphones.com.vn/x358,webp,q100/media/catalog/product/1/5/15.5.png") +
                    "<br>" +
                    "Ống kính chính trên Samsung S22 Ultra với độ phân giải lên đến 108MP, với những khả năng chụp" +
                    " ảnh đêm, chụp chân dung, chụp góc siêu rộng, và zoom quang học 100x đều hiện diện. Chi tiết ảnh và màu sắc tốt nằm trong khoảng zoom 10x, có thể sử dụng zoom 30x trong điều kiện ánh sáng tốt, còn zoom 100x mang tính chất lưu lại thông tin. Camera chính và camera tele hỗ trợ công nghệ chống rung quang học OIS." +
                    "<br>" +
                    comonFunction.ImageTag("cdn2.cellphones.com.vn/x358,webp,q100/media/catalog/product/1/5/15.3.png") +
                    "<br><br>" +
                    "Samsung Galaxy S22 Ultra 256GB ra mắt với một diện mạo “cũ mà mới”, máy sử dụng form thiết kế của dòng Galaxy Note trước đây để đưa vào dòng Galaxy S. Với hai cạnh trên và dưới vát phẳng, hai bên thì được bo cong mềm mại." +
                    "<br><br>" +
                    "Đây cũng là một chiếc smartphone vô cùng bền bỉ khi khung viền được cấu thành từ Armor Aluminum cứng cáp và đây cũng là một trong những sản phẩm được trang bị kính Corning Gorilla Glass Victus+ đầu tiên trên thị trường." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/271697/Slider/samsung-galaxy-s22-ultra-1020x570.jpg") +
                    "Thiết kế cụm camera trên máy cũng là một điểm nhận dạng Galaxy S22 Ultra năm nay khác biệt so với dòng Note, cụm camera không còn quá lồi nữa giúp cho máy không bị kênh nhiều khi đặt trên mặt phẳng." +
                    "<br><br>" +
                    "Galaxy S22 là điện thoại Samsung dòng S đầu tiên trang bị bút S Pen bên trong máy, bút S Pen năm nay cũng đã được Samsung cải tiến nhiều về độ trễ, thời gian trễ được rút ngắn lại chỉ còn 2.8 ms nên cảm giác khi viết trên màn hình Galaxy S22 Ultra này khá là chân thật và chính xác." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/271697/Slider/3.Trainghiemthigiac-1020x570.jpg") +
                    "Tất cả các tính năng như viết, các chức năng ghi chú, Screen Note, Dịch đều giống như những gì đã có trên Galaxy Note, các cử chỉ điều khiển từ xa vẫn như trên thế hệ Note, bạn cũng có thể kích hoạt camera từ xa, chuyển đổi qua lại giữa các chế độ chụp rất nhanh chóng và chính xác. Phần giao diện dường như được cập nhật theo hướng to hơn, rõ ràng hơn." +
                    "<br><br>" +
                    "Trang bị 4 ống kính với ống kính chính lên đến 108 MP, camera góc siêu rộng 12 MP, 2 camera tele cùng 10 MP hỗ trợ thu phóng quang học 10x. Năm nay Samsung đã nhấn mạnh rất nhiều qua cái câu tagline \"Mắt thần bóng đêm\", nhắc đến khả năng chụp đêm của Galaxy S22 Ultra." +
                    "<br><br>" +
                    "Thiết bị được trang bị khả năng chụp ảnh chân dung ban đêm, trong điều kiện thiếu sáng ấn tượng với bộ xử lý hình ảnh AI kết hợp với camera góc rộng 108MP mang lại bức ảnh ban đêm sáng rõ. Với không gian không quá tối, chỉ với thao tác sử dụng chế độ tự động, AI sẽ tự xử lý cho ra hình ảnh sáng, đầy đủ chi tiết và không bị nhiễu. Trường hợp thiếu sáng, chế độ chụp đêm là sự lựa chọn hoàn hảo.",
                    Hot = 1,
                    Photo = "SamsungGalaxyS22Ultra(8GB-128GB).webp",
                    Price = 30990000,
                    DiscountID = 1,
                    Amount = 50
                },
                new Products
                {
                    ID = 12,
                    Name = "Samsung Galaxy Z Flip4 128GB",
                    CategoryID = 2,
                    Decription = "Tiếp tục là một mẫu smartphone màn hình gập độc đáo, đầy lôi cuốn và mới mẻ từ hãng công nghệ Hàn Quốc, dự kiến sẽ có tên là Samsung Galaxy Z Flip 4 với nhiều nâng cấp. Đây hứa hẹn sẽ là một siêu phẩm bùng nổ trong thời gian tới và thu hút được sự quan tâm của đông đảo người dùng với nhiều cải tiến từ ngoại hình, camera, bộ vi xử lý và viên pin được nâng cấp." +
                    "<br> <br>",
                    Content = "Samsung Galaxy Z Flip 4 sở hữu thiết kế nhìn chung không có nhiều khác biệt so với thế hệ trước đó. Điện thoại vẫn sở hữu một thiết kế bao gồm hai tone màu với màn hình gập. Tuy nhiên các chi tiết sẽ được chăm chút hơn rất nhiều so với người đàn anh Z Flip 3." +
                    "<br>" +
                    "<br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/258047/Slider/vi-vn-samsung-galaxy-z-flip4--(3).jpg") +
                    "Điện thoại Samsung ZFlip 4 tiếp tục là một mẫu mã sang chảnh, thời thượng của Samsung được lấy cảm hứng từ hộp trang điểm cầm tay của các chị em hay chiếc vỏ sò. Với công nghệ gập đột phá, Samsung đã tạo ra một chiếc smartphone mang đậm dấu ấn Samsung trên thị trường. Đóng lại là phụ kiện công nghệ với kích thước 4.2-inch, vừa vặn mọi ngăn túi. Mở ra là một chiếc smartphone gập phá vỡ mọi giới hạn từ trước đến nay." +
                    "<br>" +
                    "<br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/258047/Slider/vi-vn-samsung-galaxy-z-flip4--(2).jpg") +
                    "Galaxy Z Flip 4 tiếp tục được trang bị kính siêu mỏng Ultra Thin Glass (UTG). Công nghệ màn hình này mang cho bạn trải nghiệm linh hoạt không tưởng. Bền hơn 80% so với phiên bản Z Flip trước đó. Và có gập mở đến 200.000 lần mà không gặp trục trặc gì. Phần bản lề này không chỉ bền bỉ hơn mà cũng nhỏ và nhẹ hơn." +
                    "<br>" +
                    "<br>" +
                    "Ngay từ những giây phút đầu tiên sử dụng chiếc Galaxy Z Flip4 mình đã cảm nhận được sự khác biệt của nó so với thế hệ trước, máy bây giờ đã vuông vắn hơn nhờ tạo hình vát phẳng ở hai mặt và các cạnh." +
                    "<br> <br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/258047/Slider/vi-vn-samsung-galaxy-z-flip4--(1).jpg") +
                    "Theo như hãng công bố thì phiên bản điện thoại Galaxy Z này có thể gập lên đến 200.000 lần liên tục trong phòng thí nghiệm. Nếu trung bình một ngày bạn gập, mở máy khoảng 50 lần thì mất khoảng 10 năm thì mới có thể đạt đến số lần gập này.\r\n\r\n " +
                    "<br> <br>" +
                    "Bộ khung và bản lề của sản phẩm được hoàn thiện từ vật liệu Armor Aluminum cứng cáp. Liên kết giữa các chi tiết được làm khít lại để giúp máy có thể kháng nước tốt hơn với chuẩn IPX8, từ đó giúp Galaxy Z Flip4 trở thành chiếc điện thoại gập bền bỉ nhất." +
                    "<br> <br>" +
                     comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/258047/Slider/vi-vn-samsung-galaxy-z-flip4--(6).jpg") +
                    "Với một người thích sử dụng những chiếc điện thoại màn hình lớn như mình thì trở ngại thường gặp đó chính là kích thước máy khá to, gây khó khăn cho mình trong những lúc bỏ vào túi. Thế nhưng điều này lại được khắc phục hoàn toàn trên chiếc Galaxy Z Flip4 bởi sau khi gập thì chiều dài của máy chỉ còn khoảng 84.9 mm.\r\n\r\n" +
                    "<br> <br>" +
                    "Một điểm hay trên phiên bản này là về giao diện chụp ảnh chia đôi màn hình đã hỗ trợ trên ứng dụng camera bên thứ 3, giờ đây khung hình hiển thị màn chụp sẽ được thu nhỏ và nằm vừa vặn bên trong nửa màn hình còn lại để mình dễ dàng theo dõi chất lượng ảnh, từ đó có thể chủ động hơn trong việc điều chỉnh góc chụp.\r\n\r\n" +
                    "<br> <br>" +
                     comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/258047/Slider/vi-vn-samsung-galaxy-z-flip4--(7).jpg") +
                    "Nếu nếp gấp giữa màn hình từng là một điểm yếu trên Samsung Galaxy Z Flip 3 thì điều này đã hoàn toàn được cải thiện trên thế mới kế nhiệm này. Khi mở ra, màn hình Z Flip 4 vẫn tồn tại những nếp gấp tuy nhiên nếp gấp này mờ hơn đáng kể, rất khó để nhìn thấy và hoàn toàn không ảnh hưởng đến các trải nghiệm của người dùng.",
                    Hot = 1,
                    Photo = "SamsungGalaxyZFlip4 128GB.webp",
                    Price = 23990000,
                    DiscountID = 1,
                    Amount = 50
                },
                new Products
                {
                    ID = 13,
                    Name = "Samsung Galaxy A34 5G 8GB 128GB",
                    CategoryID = 2,
                    Decription = "Tiếp tục là một mẫu smartphone màn hình gập độc đáo, đầy lôi cuốn và mới mẻ từ hãng công nghệ Hàn Quốc, dự kiến sẽ có tên là Samsung Galaxy Z Flip 4 với nhiều nâng cấp. Đây hứa hẹn sẽ là một siêu phẩm bùng nổ trong thời gian tới và thu hút được sự quan tâm của đông đảo người dùng với nhiều cải tiến từ ngoại hình, camera, bộ vi xử lý và viên pin được nâng cấp." +
                    "<br> <br>",
                    Content = "Samsung Galaxy Z Flip 4 sở hữu thiết kế nhìn chung không có nhiều khác biệt so với thế hệ trước đó. Điện thoại vẫn sở hữu một thiết kế bao gồm hai tone màu với màn hình gập. Tuy nhiên các chi tiết sẽ được chăm chút hơn rất nhiều so với người đàn anh Z Flip 3." +
                    "<br>" +
                    "<br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/303583/Slider/samsung-galaxy-a34-5g-slider---2--1020x570.jpg") +
                    "Điện thoại Samsung ZFlip 4 tiếp tục là một mẫu mã sang chảnh, thời thượng của Samsung được lấy cảm hứng từ hộp trang điểm cầm tay của các chị em hay chiếc vỏ sò. Với công nghệ gập đột phá, Samsung đã tạo ra một chiếc smartphone mang đậm dấu ấn Samsung trên thị trường. Đóng lại là phụ kiện công nghệ với kích thước 4.2-inch, vừa vặn mọi ngăn túi. Mở ra là một chiếc smartphone gập phá vỡ mọi giới hạn từ trước đến nay." +
                    "<br>" +
                    "<br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/303583/Slider/samsung-galaxy-a34-5g-slider---3--1020x570.jpg") +
                    "Galaxy Z Flip 4 tiếp tục được trang bị kính siêu mỏng Ultra Thin Glass (UTG). Công nghệ màn hình này mang cho bạn trải nghiệm linh hoạt không tưởng. Bền hơn 80% so với phiên bản Z Flip trước đó. Và có gập mở đến 200.000 lần mà không gặp trục trặc gì. Phần bản lề này không chỉ bền bỉ hơn mà cũng nhỏ và nhẹ hơn." +
                    "<br>" +
                    "<br>" +
                    "Với thiết kế đẹp và hiện đại, Galaxy A34 5G có mặt lưng nhẵn làm từ nhựa cao cấp và cụm camera được bố trí đối xứng theo một hàng dọc đầy bắt mắt. Nhờ sử dụng vật liệu nhựa giúp máy trở nên nhẹ hơn và cảm thấy thoải mái khi cầm nắm." +
                    "<br> <br>" +
                    "Galaxy A34 5G trang bị màn hình Super AMOLED kích thước 6.6 inch với thiết kế notch dạng chữ U, đi kèm với độ phân giải Full HD+ giúp hiển thị hình ảnh sắc nét, chân thực và màu sắc trung thực. \r\n\r\n" +
                    "<br> <br>" +
                    "Bên cạnh đó, tần số quét 120 Hz giúp các thao tác chạm vuốt trên màn hình được thực hiện một cách mượt mà và phản hồi nhanh hơn, mang đến trải nghiệm thị giác tuyệt vời cho người dùng." +
                     comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/303583/Slider/samsung-galaxy-a34-5g-slider---7--1020x570.jpg") +
                    "<br> <br>" +
                    "Galaxy A34 5G được trang bị bộ vi xử lý MediaTek Dimensity 1080, chip có thể hoạt động lên đến tốc độ tối đa 2.6 GHz, điều này tạo nên một hiệu năng mạnh mẽ giúp thực hiện các tác vụ hằng ngày một cách mượt mà và nhanh chóng." +
                    "<br> <br>" +
                     comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/303583/Slider/samsung-galaxy-a34-5g-128gb638155096162739473.jpg") +
                    "<br> <br>" +
                    "Nếu nếp gấp giữa màn hình từng là một điểm yếu trên Samsung Galaxy Z Flip 3 thì điều này đã hoàn toàn được cải thiện trên thế mới kế nhiệm này. Khi mở ra, màn hình Z Flip 4 vẫn tồn tại những nếp gấp tuy nhiên nếp gấp này mờ hơn đáng kể, rất khó để nhìn thấy và hoàn toàn không ảnh hưởng đến các trải nghiệm của người dùng.",
                    Hot = 1,
                    Photo = "SamsungGalaxyA345G8GB128GB.webp",
                    Price = 8490000,
                    DiscountID = 1,
                    Amount = 50
                },
                new Products
                {
                    ID = 14,
                    Name = "Samsung Galaxy S20 FE 256GB",
                    CategoryID = 2,
                    Decription = "Samsung S20 FE là chiếc điện thoại sắp được ra mắt từ Samsung, với chữ FE đằng sau tên gọi của máy có nghĩa là Fan Edition. Đây là dòng điện thoại ra mắt như để gửi lời tri ân đến các fan trung thành đã và đang sử dụng các sản phẩm của Samsung. Với số lượng sản phẩm được giới hạn và chỉ mở bán trong thời gian ngắn.  " +
                    "<br> <br>",
                    Content = "<b>Màn hình Super Amoled 6.5 inch, FullHD, công nghệ HDR10+, tần số quét 120Hz</b><br>" +
                    "Được định hướng vẫn là sản phẩm ở phân khúc cao cấp, Galaxy S20 Fan Edition được trang bị tấm nền Super Amoled cao cấp, kích thước màn hình lớn lên đến 6.5 inches, màn hình độ phân giải FullHD giúp hình ảnh hiển thị trên chiếc điện thoại này là vô cùng sắc nét và rực rỡ." +
                    "<br>" +
                    "<br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/224859/Slider/samsung-galaxy-s20-fan-edition-tongquan-780x433-1.jpg") +
                    "Không bỏ lỡ trào lưu tần số quét cao, điện thoại được trang bị một màn hình với tần số quét 120Hz, công nghệ hình ảnh HDR10+ tăng độ tương phản, giúp bạn có những phút giây giải trí hoàn hảo dù là chơi game hay xem phim." +
                    "<br>" +
                    "<br>" +

                    "Trái tim của Galaxy S20 FE chính là bộ vi xử lý Snapdragon 865 8 nhân giúp máy hoạt động mạnh mẽ, nhưng vẫn tiết kiệm được pin nhờ áp dụng tiến trình sản xuất nhỏ hơn." +
                    "<br>" +
                    "<br>" +
                     comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/224859/Slider/samsung-galaxy-s20-fan-edition-cauhinh-780x433.jpg") +
                    "Ngoài ra chuẩn bộ nhớ UFS 3.1 mới nhất cho tốc độ đọc ghi lần lượt là 2100Mb/s, 1200Mb/s. Ấn tượng nhất trong phân khúc các điện thoại đầu bảng hiện này, giúp Samsung Galaxy S20 Fan Edition có thể load các ứng dụng hay trao đổi file trên máy tính nhanh chóng hơn." +
                    "<br>" +
                    "<br>" +
                     comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/224859/Slider/samsung-galaxy-s20-fan-edition-sac-780x433.jpg") +
                    "Giao diện mới thêm vào một loạt tính năng về camera như Singe Take, Night Hyperlapse và chế độ Video Pro. Tính năng Samsung Dex giờ đây đã cho phép kết nối không dây như Tivi thông minh hay màn hình có tính năng Screen Mirroring." +
                    "<br>" +
                    "<br>" +
                    "Về phần hiệu năng, Samsung đã dành tặng cho các fan game thủ chiếc điện thoại chơi game khi trang bị cho máy con Snapdragon 865 8 nhân mạnh mẽ hàng đầu thế giới đi cùng chip đồ họa Adreno 650 cho phép bạn bật cấu tính tối đa để trải nghiệm những dòng game nặng hiện nay mà không hề lo lắng tình trạng giật lag." +
                    "Không chỉ trang bị những tính năng hấp dẫn S20 FE còn là người bạn đồng hành cả ngày dài với bạn khi sở hữu dung lượng pin trâu lên tới 4500 mAh cho phép bạn sử dụng các tác vụ giải trí hằng ngày như lướt web, xem phim mà không bị gián đoạn.",
                    Hot = 1,
                    Photo = "Samsung Galaxy S20 FE 256GB.webp",
                    Price = 12490000,
                    DiscountID = 1,
                    Amount = 50
                },
                new Products
                {
                    ID = 15,
                    Name = "Samsung Galaxy S23 8GB 256GB",
                    CategoryID = 2,
                    Decription = "<b>Samsung Galaxy S23</b> là phiên bản tiếp theo sắp được Samsung cho ra mắt thị trường. Sở hữu diện mạo tinh tế mới mẻ đi đầu xu hướng, bên cạnh đó là màn hình chất lượng, hiệu năng mạnh mẽ và cụm camera siêu chất sẽ mang tới những trải nghiệm ấn tượng cho người dùng ngay từ lần chạm đầu tiên." +
                    "<br> <br>",
                    Content = "Samsung Galaxy S23 sở hữu trên mình thiết kế sang trọng, tinh tế và hấp dẫn người dùng ngay từ ánh nhìn đầu tiên. Toàn bộ các góc cạnh được bo tỉ mỉ mang tới sự mềm mại mà không kém phần chắc chắn." +
                    "<br> <br>" +
                    "Máy được hoàn thiện vô cùng bền bỉ nhờ khung viền được cấu thành từ chất liệu Armor Aluminum có khả năng kháng bụi, chống nước chuẩn IP68. Bên cạnh đó, màn hình được bảo vệ bởi lớp kính cường lực Corning Gorilla Glass Victus 2 siêu bền bỉ giúp đảm bảo sự an toàn của thiết bị trong quá trình sử dụng." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/301795/Kit/samsung-galaxy-s23-note.jpg") +
                    "Phần cụm camera phía sau của S23 có thiết kế lồi hơn so với mặt lưng nhưng sở hữu màu sắc tương đồng. Từ đó mang tới sự tối ưu và vô cùng gọn gàng cho tổng thể thiết kế." +
                    "<br> <br>" +
                    "Samsung Galaxy S23 được trang bị màn hình 6.1 inch kết hợp với đó là khung viền mỏng, thiết kế giọt nước giúp không gian hiển thị được tối ưu hơn. Màn hình có tốc độ làm tươi cực ấn tượng cho mọi thao tác vuốt chạm cũng như phản hồi màn hình vô cùng mượt mà và nhanh chóng." +
                    "<br>" +
                    "<br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/301795/Slider/vi-vn-samsung-galaxy-s23-5g-256gb--(6).jpg") +
                    "Máy còn sở hữu tấm nền chất lượng cao với độ phân giải lớn cho khả năng hiển thị sắc nét. Đặc biệt, màu đen sâu, màu sắc kết hợp hài hoà, dải màu rộng cùng với đó là công nghệ hiện đại giúp bạn có trải nghiệm giải trí sinh động hơn và cũng đảm bảo đôi mắt được bảo vệ tốt hơn khi sử dụng." +
                    "<br> <br>" +
                    "Thật sự mà nói, Galaxy S23 5G 256GB có chất lượng hoàn thiện khá cao, từng chi tiết trên sản phẩm được gia công rất cẩn thận, khung máy được chế tác bằng kim loại cứng cáp và bền bỉ. Với kiểu dáng nhỏ gọn của mình, thiết bị cho cảm giác cầm nắm khá là chắc chắn và đằm tay." +
                    "<br> <br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/301795/Slider/man-hinh-s23-series-1020x570.jpg")+
                    "Giống với đàn anh đã ra mắt trước đó, mặt lưng của Galaxy S23 5G 256GB cũng được hoàn thiện từ kính với thiết kế phẳng, viền màn hình được làm mỏng ở cả 4 cạnh trông rất cân đối. Tuy nhiên, cụm camera phía sau lại có chút thay đổi, đi theo hơi hướng thiết kế giống trên mẫu Galaxy S22 Ultra với kiểu bố trí ống kính riêng lẻ và không đặt chung cụm.\r\n\r\n" +
                    "<br> <br>" +
                    "Galaxy S23 được hãng ưu ái trang bị màn hình Dynamic AMOLED 2X kích thước 6.1 inch, độ phân giải Full HD+ cùng tần số quét 120 Hz, điều này mang lại khả năng hiển thị hình ảnh vô cùng chi tiết với màu đen sâu và được bảo vệ bởi kính cường lực cao cấp." +
                    "<br> <br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/301795/Slider/vi-vn-samsung-galaxy-s23-5g-256gb--(2).jpg") +
                    "Galaxy S23 5G 256GB có hệ thống 3 camera cực chất lượng phía sau gồm camera chính độ phân giải 50 MP, camera góc siêu rộng 12 MP và camera tele 10 MP. Nhờ việc vừa chú trọng vào phần cứng vừa tập trung vào thuật toán xử lý ảnh, hãng đã giúp những bức ảnh chụp được trên chiếc điện thoại này trở nên sinh động và chân thực hơn." +
                    "<br> <br>" +
                    "Đối với những bạn có sở thích quay vlog hay muốn lưu giữ lại kỷ niệm qua những thước phim thì tính năng quay video sắc nét trên thiết bị sẽ đáp ứng tốt mọi nhu cầu ghi hình dành cho bạn." +
                    "<br> <br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/301795/Slider/pin-s23-series-1-1020x570.jpg") +
                    "Ngoài ra, camera trước của chiếc điện thoại Samsung Galaxy dòng S này còn có độ phân giải 12 MP và được hỗ trợ nhiều chế độ chụp ảnh tiên tiến, đối với điều kiện ánh sáng yếu thì máy vẫn cho ra chất ảnh tươi sáng, nịnh mắt và rõ nét." +
                    "<br> <br>" +
                    "Samsung Galaxy S23 là chiếc smartphone vô cùng chất lượng với những điểm vượt trội về thiết kế, hiệu năng và camera cực kỳ chất lượng. Chắc chắn đây sẽ là thiết kế phù hợp với những ai yêu thích một mẫu điện thoại cao cấp, nhỏ gọn và yêu thích công nghệ.",
                    Hot = 1,
                    Photo = "SamsungGalaxyZFlip4 128GB.webp",
                    Price = 24990000,
                    DiscountID = 1,
                    Amount = 50
                },
                new Products
                {
                    ID = 16,
                    Name = "Samsung Galaxy Z Fold4",
                    CategoryID = 2,
                    Decription = "Theo các nguồn thông tin gần đây, điện thoại Galaxy Z Fold 2022sẽ có những điểm mới về màu sắc, phiên bản dung lượng bộ nhớ, hiệu năng, camera cùng thiết kế mới. Dưới đây là những thông tin mới nhất về siêu phẩm màn hình gập <b>Samsung Z Fold 4</b> vừa được trình làng mới đây.",
                    Content = "<br><br>" +
                    "Samsung Galaxy Fold 4 được cho là sẽ có nhiều điểm đổi mới, cải tiến về mặt thiết kế, hiệu năng và nhiều tính năng hấp dẫn khác so với thế hệ trước đó. Nhờ vậy, người dùng lại có thêm các trải nghiệm mới mẻ trong quá trình sử dụng siêu phẩm. " +
                    "<br>" +
                    "<br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/250625/Slider/vi-vn-samsung-galaxy-z-fold4--(1).jpg") +
                    "Cụm camera sau có khả năng thu phóng nhiều lần, đồng thời camera “Mắt thần bóng đêm” được nâng cấp các tính năng chuyên nghiệp. Đặc biệt khi chụp đêm, hình ảnh vẫn sắc nét, chi tiết, video mượt mà nhờ công nghệ OIS, VDIS và Super Night Solution giảm nhiễu." +
                    "<br>" +
                    "<br>" +
                    "Ngoài ra, Z Fold4 còn mang đến những bức chân dung tuyệt đẹp bằng camera sau kể cả ở điều kiện thiếu sáng. Nhờ vào bộ phận tinh xảo của camera cùng phần mềm cải tiến nên ánh sáng được cải thiện đáng kể. Bộ vi xử lý còn giúp tăng cường chi tiết và màu sắc cho hình ảnh." +
                    "<br> <br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/250625/Slider/samsung-galaxy-z-fold4-ban-le-1020x570.jpg") +
                    "Galaxy Z Fold4 là siêu phẩm Samsung đầu tiên sử dụng hệ điều hành Android 12 L, chạy trên One UI 4.1.1. Ở hệ điều hành này, Z Fold4 đã tối ưu hóa được các ứng dụng chạy trên màn hình gập bằng tác vụ chuyên dụng. Nhờ vậy, việc chuyển đổi giữa các ứng dụng trở nên đơn giản và dễ dàng hơn. Đặc biệt Android 12L cho phép người dùng chuyển đổi cài đặt nhanh và sử dụng 2 cột thông báo." +
                    "<br> <br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/250625/Slider/vi-vn-samsung-galaxy-z-fold4--(7).jpg") +
                    "Chỉ với tính năng Multi View trên chiếc màn hình gập của Z Fold4, thế giới số của bạn tiện lợi vô cùng. Dù muốn kiểm tra email hay thực hiện công việc với văn bản, các tác vụ đều được thực hiện nhanh chóng trong nháy mắt. Điều này nhằm tối ưu hóa trải nghiệm người dùng trên các ứng dụng." +
                    "<br><br>" +
                    "Trong phân khúc sản phẩm cao cấp này, iPhone 14, Oppo Find N, Vivo X Fold hay Google Pixel sẽ là đối thủ cạnh tranh nặng ký với Fold 4. Tuy nhiên, nếu bạn là fan nhà Samsung hoặc tín đồ công nghệ thích khám phá những công nghệ mới, đón đầu công nghệ thì không nên bỏ qua siêu phẩm màn hình gập này.",
                    Hot = 1,
                    Photo = "Samsung Galaxy Z Fold4.webp",
                    Price = 40990000,
                    DiscountID = 1,
                    Amount = 50
                },
                new Products
                {
                    ID = 17,
                    Name = "Samsung Galaxy A23 5G",
                    CategoryID = 2,
                    Decription = "<b>Samsung Galaxy A23</b> được trang bị cấu hình vượt trội với con chip Snapdragon 695 5G cùng viên pin 5000 mAh thoải mái trải nghiệm. Màn hình 6.6 inch LCD mang lại khả năng hiển thị rõ nét. Điểm đặc biệt, mẫu điện thoại Samsung này còn được trang bị kết nối 5G đầy tiện lợi." +
                    "<br> <br>",
                    Content = "Galaxy A23 5G mang một sức mạnh tuyệt vời, để có thể làm việc được hiệu suất và nhiều hơn thế. Đó là nhờ sự kết hợp sức mạnh của bộ vi xử lý Snapdragon 695 tám nhân." +
                    "<br> <br> " +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/272016/Slider/samsung-galaxy-a23-5g-slider---1--1020x570.jpg") +
                    "Đồng thời thiết bị còn được hỗ trợ RAM 4GB để giúp tăng hiệu quả làm việc và nhanh chóng hơn. Bộ nhớ trong 64GB cùng sự hỗ trợ của thẻ MicroSD có thể lên đến tối đa 1TB mang đến một không gian lưu trữ rộng lớn và khả năng đa nhiệm mượt mà. Điện thoại cũng được trang bị sự bảo mật an toàn, nhiều lớp, giúp bảo vệ thông tin an toàn và tránh được những đe dọa độc hại." +
                    "<br> <br>" +
                    "Chiếc điện thoại Samsung Galaxy A23 5G sẽ mang đến cái nhìn tổng thể vô cùng tuyệt vời qua những hình ảnh được tiết lộ. Màn hình Infinity-V IPS LCD kích thước 6.6 inch sẽ được giữ lại. Thêm vào đó là tính năng cuộn siêu mượt, giúp cho người dùng có trải nghiệm lướt hiệu quả hơn." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/272016/Slider/samsung-galaxy-a23-5g-slider---5--1020x570.jpg") +
                    "Với màn hình này, Samsung Galaxy A23 5G sẽ mang đến cho bạn một không gian xem, giải trí và làm việc hiệu quả hơn. Công nghệ FHD + kết hợp với tốc độ làm mới 120Hz sẽ giúp bạn có thể trải nghiệm chơi game, các nội dung yêu thích sắc nét và mượt mà hơn." +
                    "<br><br>" +
                    "Về thiết kế vẻ ngoài thì những hình ảnh cho thấy Samsung Galaxy A23 5G cũng không có khác biệt nhiều so với phiên bản trước đó. Thay vào đó chúng sẽ được bổ sung thêm một màu sắc mới. Đồng thời, với kết nối 5G, người dùng sẽ hoàn toàn có cái nhìn khác về công nghệ kết nối của Samsung. Những nhu cầu về chia sẻ, chơi game, phát trực tuyến, tải xuống đều sẽ được đáp ứng tốt với mạng di động thế hệ mới." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/272016/Slider/samsung-galaxy-a23-5g-slider---2--1020x570.jpg") +
                    "Việc sở hữu viên pin 5.000 mAh chắc cũng không còn lạ gì trên những thiết bị di động của Samsung. Và với phiên bản 5G này, thiết bị sẽ được trang bị viên pin 5000 mAh cùng với đó là công nghệ sạc nhanh 25W, giúp người dùng tiết kiệm thời gian sạc nhiều hơn. Đồng thời, chế độ Game Booster đã mang lại lợi thế cho những ai thường xuyên chơi game trên thiết bị. Game Booster không những tối ưu pin nhiệt độ, bộ nhớ mà còn giúp chặn các thông báo, hoạt động nền gây ảnh hưởng đến trận chiến của bạn.",
                    Hot = 1,
                    Photo = "Samsung Galaxy A23 5G.webp",
                    Price = 5990000,
                    DiscountID = 1,
                    Amount = 50
                },
                new Products
                {
                    ID = 18,
                    Name = "Samsung Galaxy Z Fold3 5G",
                    CategoryID = 2,
                    Decription = "Với sự thành công đáng kinh ngạc và luôn cháy hàng từ lúc ra " +
                    "mắt đến thời điểm hiện tại của hai thế hệ trước là Fold 1 và Z Fold 2. Phiên bản <b>Samsung Galaxy Z Fold3</b> lần này được ra mắt với độ hoàn thiện cao về thiết kế và hiệu năng. " +
                    "Mang đến cho người dùng một trải nghiệm cực kỳ thú vị hơn.",
                    Content = "<br> <br>" +
                    "Là sản phẩm mang đến độ hoàn thiện cao hơn nhiều so với hai phiên bản trước, điện thoại màn hình gập mới được thiết kế kích thước hài hòa hơn. Giúp bạn có thể dễ dàng cầm khi đóng hoặc mở màn hình đều dễ sử dụng nhất. Bộ khớp nối bản lề mới giúp kết nối bộ khung của Samsung Fold 3 hoàn hảo hơn. Tăng cao độ bền khi đóng mở liên tục và cố định cực kỳ chắc chắn." +
                    "<br> <br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/248284/Slider/samsung-galaxy-z-fold-3-slider-1020x570-1.jpg") +
                    "Chất liệu trên toàn bộ bề mặt của chiếc điện thoại Galaxy Z Fold3 được làm từ kim ngoại cao cấp nguyên khối, được CNC bộ khung rất chính xác và mỏng. Không làm tăng lên khối lượng của chiếc điện thoại quá nhiều và luôn giữ được vẻ ngoài nổi bật với chất liệu kim loại nguyên khối này. Phần logo Samsung được in nổi trên khớp nối của 2 màn hình khi đóng lại lộ ra ngoài rất bắt mắt và mất đi đầy tinh tế khi đóng màn hình trở lại." +
                    "<br><br>" +
                    "Đặc biệt góc mở rộng của chiếc điện thoại Samsung Galaxy Z này lên đến 180 độ và có thể điều chỉnh góc dễ dàng và cố định rất tiện lợi dễ nhìn như một chiếc laptop thu nhỏ lại nằm ngay trước mặt của bạn." +
                    "<br> <br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/248284/Slider/samsung-galaxy-z-fold3-5g-512gb-060921-0207397.jpg") +
                    "Cụ thể, Galaxy Z Fold3 được trang bị con chip Snapdragon 888 cho xung nhịp xử lý nằm ở mức khá cao. Giúp mọi thao tác mọi ứng dụng đều được xử lý nhanh chóng trên cả 2 màn hình rất hiệu quả và mượt mà. Bộ nhớ ram của máy cũng cho dung lượng lên đến 12GB ngang mới một một chiếc laptop cao cấp. Thế hệ ram là loại DDR5 tối ưu đa nhiệm cực tốt, hầu hết mọi ứng dụng nặng nhất đều có thể sử dụng cùng lúc mượt mà.\r\n\r\n" +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/248284/Slider/samsung-galaxy-z-fold3-5g-512gb-060921-0207382.jpg") +
                    "Samsung cũng cung cấp đến cho người dùng nhiều sự lựa chọn về bộ nhớ máy với dung lượng chuẩn là 256GB, một không gian lớn giúp lưu trữ dễ dàng hơn hàng ngày." +
                    "<br><br>" +
                    "Còn ở thời điểm hiện tại, mức giá của Samsung Fold 3 đã được hạ xuống ở mức cực kỳ hấp dẫn tại hệ thống bán lẻ di động CellphoneS. Tại đây, giá bán của sản phẩm chỉ khoảng hơn 30 triệu đồng. Đây là cơ hội thích hợp để bạn có thể sở hữu siêu phẩm hàng đầu thế giới hiện nay",
                    Hot = 1,
                    Photo = "Samsung Galaxy Z Fold3 5G.webp",
                    Price = 41990000,
                    DiscountID = 1,
                    Amount = 50
                },
                // Add XiaoMi
                new Products
                {
                    ID = 19,
                    Name = "Xiaomi Redmi Note 12 Pro 5G",
                    CategoryID = 3,
                    Decription = "<b>Xiaomi Redmi Note 12 Pro</b> sở hữu cấu hình vượt trội gồm chip MediaTek Dimensity 1080, hệ thống ba camera với cảm biến chính 50MP và mạng 5G. Ngoài ra, màn hình Note 12 Pro 5G có kích thước khá lớn khoảng 6.67 inch, tấm nền AMOLED, tần số quét 120Hz khiến chiếc điện thoại nổi bật trong tầm giá dưới 8 triệu" +
                    "<br> <br>",
                    Content = "Tuy sở hữu cùng một kích thước màn hình tuy nhiên Xiaomi Redmi Note 12 Pro được trang bị tấm nền OLED cao cấp. Đặc biệt phải kể đến trên mẫu điện thoại đó chính là dải màu rộng lên đến 1 tỷ màu cùng với công nghệ hiển thị Dolby Vision và HDR10+. Công nghệ mới này giúp điện thoại mang lại khả năng hiển thị sống động, màu sắc tươi sáng, màu đen sâu. Kết hợp với độ sáng được nâng cấp lên 900 nits giúp điện thoại có thể hiển thị tốt trong nhiều điều điện ánh sáng khác nhau, kể cả ngoài trời" +
                    "<br>" +
                    "<br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/278886/Slider/xiaomi-redmi-note-12-pro-5g638162920733414283.jpg") +
                    "Nếu như thế hệ trước đó chạy trên con chip snapdragon thì thế hệ Redmi Note 12 Pro chạy trên con chip Dimensity 1080 của MediaTek. Cụ thể, hiệu suất trên con chip Dimensity 1080 vượt trội trên Snapdragon 695 về nhiều tiêu chí. Đặc biệt trong đó là khả năng tiết kiệm điện năng." +
                    "<br><br>" +
                    "Tuy độ phân giải trên Redmi Note 12 Pro giảm so với thế hệ trước tuy nhiên điện thoại mới này lại được trang bị cảm biến chống rung OIS. Do đó, tuy thông số bị sụt giảm nhưng chất lượng hình ảnh mà điện thoại mang lại không hề giảm. Kết hợp với cảm biến IMX766 của Sony và thấu kính 1/1.56 inch nhờ đó hình ảnh mang lại với độ sáng cao, khả năng lấy nét nhanh." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/278886/Slider/xiaomi-redmi-note-12-pro-5g638162920741314294.jpg") +
                    "Nhìn chung, Xiaomi Redmi Note 12 Pro có nhiều nâng cấp so với phiên bản thường từ cấu hình, camera đến tốc độ sạc nhanh. Tuy nhiên Xiaomi Redmi Note 12 có giá bán rẻ hơn rất nhiều so với phiên bản Pro. Do đó nếu không gặp phải những vấn đề về tài chính thì Xiaomi Redmi Note 12 Pro là lựa chọn hoàn hảo. Tuy nhiên nếu khả năng tài chính của bạn chưa cao thì Xiaomi Redmi Note 12 vẫn là một sản phẩm đáng để trải nghiệm" +
                    "<br>" +
                    "<br>" +
                    "Xiaomi Redmi Note 12 Pro 5G gây ấn tượng nổi bật với nhiều người tiêu dùng ngay từ thời điểm mới ra mắt nhờ vào thiết kế đẹp mắt, cùng bộ cấu hình vượt trội. Chiếc điện thoại ghi điểm với khả năng chụp ảnh sắc nét, chân thực, cùng với màn hình AMOLED vô cùng rực rỡ. Redmi Note 12 Pro 5G là sự lựa chọn hàng đầu của nhiều bạn." +
                    "<br>" +
                    "<br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/278886/Slider/xiaomi-redmi-note-12-pro-5g-ff-2048x1144.jpg") +
                    "Xiaomi Redmi Note 12 Pro 5G lần đầu được giới thiệu tại thị trường Trung Quốc vào ngày 27/10 năm 2022. Sau đó một vài tháng, máy được Xiaomi giới thiệu đến thị trường Quốc tế tại, cụ thể là ngày 5/01/2023 tại thị trường Ấn Độ. Tại Việt Nam, Redmi Note 12 Pro ra mắt vào 29/03/2023 với bộ nhớ 6GB/128GB. Với sự đa dạng này, người dùng sẽ được mở rộng sự lựa chọn của mình với tiêu chí về bộ nhớ." +
                    "<br>" +
                    "<br>" +
                    "Xiaomi Redmi Note 12 Pro 5G với giá bán hấp dẫn, cùng bộ cấu hình ấn tượng xứng đáng là sự lựa chọn hoàn hảo dành cho những ai đang tìm kiếm một chiếc smartphone ngon, bổ, rẻ",
                    Hot = 1,
                    Photo = "Xiaomi Redmi Note 12 Pro 5G.webp",
                    Price = 9490000,
                    DiscountID = 1,
                    Amount = 50
                },
                new Products
                {
                    ID = 20,
                    Name = "Xiaomi Redmi Note 11 128GB",
                    CategoryID = 3,
                    Decription = "<b>Xiaomi Redmi Note 11 phiên bản 4GB/128GB</b> được trang bị bộ vi xử lý Snapdragon 680 cùng viên pin 5.000 mAh sạc nhanh 33W. Điện thoại sở hữu bộ tứ camera bao gồm cảm biến chính độ phân giải 50MP, ống kính góc siêu rộng 8MP, camera macro 2MP và cảm biến đo độ sâu trường ảnh 2MP."
                    + "<br> <br>",
                    Content = "Ngoài ra, Redmi Note 11 còn được trang bị màn hình AMOLED với kích thước 6.43 inch hỗ trợ độ phân giải Full HD+ và tần số quét 90Hz. Mặt trước có thiết kế đục lỗ theo xu hướng smartphone hiện nay." +
                    "<br> <br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/269832/Slider/note-110-1020x570.jpeg") +
                    "Đặc biệt, tần số quét màn hình lên đến 90 Hz cho cảm giác chạm, vuốt, cuộn màn hình cực mượt, chuyển cảnh độ trễ thấp cho khung hình luôn liền mạch, là điểm cộng khi sử dụng điện thoại để chơi các tựa game tốc độ, game hành động." +
                    "<br><br>" +
                    "Chip Snapdragon 680 cùng với chip đồ họa Adreno 610 và RAM 4 GB cho khả năng xử lý khá mạnh mẽ và mượt mà, các tác vụ lướt web, nghe nhạc, xem phim, chỉnh sửa ảnh,… đều trơn tru và ổn định, thậm chí bạn có thể với các tựa game mobile như: Liên Quân Mobile, PUBG Mobile cấu hình tầm trung trên máy." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/269832/Slider/SLIDE24128-1020x570.jpg") +
                    "Điện thoại Xiaomi có bộ nhớ trong 128 GB đủ dùng cho kho hình ảnh và tài liệu cá nhân trên máy. Hệ điều hành Android 11 giao diện MIUI 13 thân thiện dễ dùng, rất thoải mái khi trải nghiệm." +
                    "<br><br>" +
                    "Sở hữu viên pin dung lượng 5000 mAh bền bỉ cùng với công nghệ siêu tiết kiệm pin đạt hiệu quả tốt từ con chip sử dụng, smartphone này cho phép bạn thoải mái đàm thoại, xem video hay chơi game nhiều giờ liền mà không ái ngại việc cạn nguồn quá nhanh." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/269832/Slider/SLIDE4new-1020x570.jpg") +
                    "Cùng với công nghệ sạc pin nhanh 33 W, việc khôi phục 100% dung lượng pin cho điện thoại sẽ không mất nhiều thời gian chờ, yên tâm sử dụng điện thoại theo nhu cầu.",
                    Hot = 1,
                    Photo = "Xiaomi Redmi Note 11 128GB.webp",
                    Price = 4990000,
                    DiscountID = 1,
                    Amount = 50
                },
                new Products
                {
                    ID = 21,
                    Name = "Xiaomi 13 8GB 256GB",
                    CategoryID = 3,
                    Decription = "<b>Xiaomi 13</b> là sản phẩm mới được trang bị màn hình OLED kích thước 6.36 inch cùng tần số quét lên đến 120Hz. Bên trong Xiaomi 13 là con chip Snapdragon 8 Gen 2 mới nhất cùng bộ nhớ RAM 8GB vượt trội. Điện thoại cũng đáp ứng tốt khả năng nhiếp ảnh với camera Leica 50MP." +
                    "<br><br>",
                    Content = "<b>Xiaomi 13</b> mẫu điện thoại cao cấp mới của Xiaomi với mức giá nhỉnh hơn một chút so với Xiaomi 12 Pro. Vậy ở thời điểm này thì nên nâng cấp Xiaomi 13 với nhiều tính năng mới hay mua Xiaomi 12 Pro với mức giá rẻ hơn, hãy cùng tìm hiểu ngay sau đây." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/267984/Slider/vi-vn-xiaomi-13-slider-fix--(1).jpg") +
                    "Xiaomi 13 được đánh giá cao về giao diện cho đến hiệu năng của sản phẩm, nhờ sự luôn luôn đổi mới, bắt kịp nhu cầu người dùng, nên sản phẩm này đang được tìm kiếm thông tin nhiều nhất. Xiaomi 13 chắc chắn sẽ không khiến người dùng thất vọng về những gì mà điện thoại này mang lại." +
                    "<br><br>" +
                    "Xiaomi 13 mang giao diện ưa nhìn, mang nét sang trọng, pha một chút thanh lịch, với các chi tiết được hoàn thiện tỉ mỉ đẹp mắt. Các góc cạnh vuông tinh tế, mặt lưng từ chất liệu polymer silicon kết hợp công nghệ nano-skin giúp chống trầy xước, bụi bẩn. Đồng thời mặt sau thiết kế cụm camera ở góc trên cùng bên trái màn hình." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/267984/Slider/vi-vn-xiaomi-13-slider-fix--(2).jpg") +
                    "Xiaomi 13 có nút khởi động và âm lượng thuận tiện, người dùng dễ dàng khởi động máy, các thao tác trên điện thoại đơn giản, kể cả người mới sử dụng lần đầu. Bên cạnh đó, máy còn thiết lập mật khẩu để người dùng có độ bảo mật cao nhất, tránh các trường hợp kẻ xấu lấy cắp thông tin quan trọng." +
                    "<br><br>" +
                    "Xiaomi 13 có màn hình OLED rộng lên đến 6.36 inch, độ phân giải FHD+ người dùng sẽ có trải nghiệm ấn tượng khi xem phim, chơi game trên điện thoại. Máy còn có trọng lượng khá nhẹ, sẽ như người bạn đồng hành cùng người dùng trong những chuyến đi xa." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/267984/Slider/vi-vn-xiaomi-13-slider--(6).jpg") +
                    "Điện thoại Xiaomi 13 có tần số quét 120Hz giúp hình ảnh hiển thị luôn rõ nét, không bị lỗi mờ khi sử dụng. Sở hữu hàng triệu sắc màu được hiển thị khi trải nghiệm chiến game, xem phim, giúp người dùng có những phút giây thăng hoa với nghệ thuật sắc màu." +
                    "<br><br>" +
                    "Cụ thể phiên bản RAM 8GB và bộ nhớ trong 128GB: 3999NDT (khoảng 13.5 triệu đồng), bản RAM 8GB + bộ nhớ trong 256GB:4299NDT (khoảng 14.6 triệu đồng). Một số sản phẩm có cùng phân khúc sẽ là đối thủ cạnh tranh với Xiaomi 13 như: Reno5 5G, Nokia G50, Samsung Galaxy A73,… các hãng khác phải quan tâm đến sản phẩm mới nhà Xiaomi vì các thông số ấn tượng mà sản phẩm này mang lại.",
                    Hot = 1,
                    Photo = "Xiaomi 13 8GB 256GB.webp",
                    Price = 22990000,
                    DiscountID = 1,
                    Amount = 50
                },
                new Products
                {
                    ID = 22,
                    Name = "Xiaomi Mi 11 Lite 5G",
                    CategoryID = 3,
                    Decription = "Điện thoại Mi 11 Lite 5Glà sản phẩm tầm trung nhưng vẫn sở hữu rất nhiều điểm nổi bật từ thiết kế đến cấu hình, như trên những chiếc smartphone cao cấp. Đây là một máy đáng để trải nghiệm, với những người dùng có nhu cầu tìm kiếm cho mình một chiếc điện thoại thông minh với màn hình lớn, sạc nhanh và dung lượng lớn nhưng có mức giá tốt. " +
                     "<br> <br>",
                    Content = "Xiaomi Mi 11 Lite phiên bản 5G có vẻ ngoài khá bắt mắt với màn hình tràn viền, mang đến cho người dùng kích thước màn hình lớn hơn, không gian hiển thị thoải mái. Camera selfie dạng đục lỗ ở góc trên bên trái màn hình, vừa tiết kiệm diện tích, vừa tạo cho smartphone vẻ đẹp sang trọng, cao cấp hơn." +
                     "<br><br>" +
                     comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/249427/Slider/xiaomi-11-lite-5g-slider-tong-quan-1020x570.jpg") +
                     "Ngoài ra, màn hình sở hữu tần số quét lên đến 90Hz. Đây là mức tần số quét thường có ở những dòng smartphone cao cấp, giá thành cao. Nên việc Xiaomi Mi 11 Lite sở hữu thông số này là điểm cộng rất lớn." +
                     "<br><br>" +
                     "Tần số 90Hz giúp màn hình hiển thị chân thực, sắc nét, màu sắc tươi mới trên từng chuyển động, không gặp phải tình trạng xe hay giật hình, kể cả với những khung hình có chuyển động nhanh." +
                     "<br><br>" +
                     comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/249427/Slider/xiaomi-11-lite-5g-ne637683486679375757.jpg") +
                     "Điện thoại được Xiaomi trang bị chip Snapdragon 780G với hiệu năng được nâng cấp đáng kể so với chip Snapdragon 730G tiền nhiệm, tăng 15% đối với đồ họa. Nhờ đó, máy vẫn có khả năng xử lí tốt, nhanh chóng tác vụ." +
                     "<br><br>" +
                     "<br><br>" +
                     "Máy sẽ có dung lượng RAM vô cùng lớn lên đến 8GB RAM. Với dung lượng RAM 8GB hoàn toàn đủ khả năng để điều khiển dữ liệu trên Xiaomi Mi 11 Lite với tốc độ ổn định." +
                     "<br><br>" +
                     "<br><br>" +
                     comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/249427/Slider/xiaomi-11-lite-5g-ne637683486667725817.jpg") +
                     "Bộ nhớ trong 128GB cho phép lưu trữ khá lớn ứng dụng, hình ảnh và video clip. Nếu bạn có nhu cầu lưu trữ và tải nhiều ứng dụng, thì mức dung lượng 128GB đủ sức đáp ứng yêu cầu của bạn.\r\n\r\n" +
                     "<br><br>" +
                     "<br><br>" +
                     "Chiếc smartphone này có tất cả 3 phiên bản màu sắc vô cùng trẻ trung và năng động bao gồm đen, xanh ngọc, vàng giúp khách hàng dễ dàng lựa chọn tùy vào sở thích của từng người. ",
                    Hot = 1,
                    Photo = "Xiaomi Mi 11 Lite 5G.webp",
                    Price = 10490000,
                    DiscountID = 1,
                    Amount = 50
                },
                new Products
                {
                    ID = 23,
                    Name = "Xiaomi Poco F4",
                    CategoryID = 3,
                    Decription = "<b>Xiaomi Poco F4</b> sản phẩm làm nhiều tính đồ công nghệ mong chờ, với thiết kế và hiệu năng nổi bật, mang sự đặt biệt của thương hiệu điện thoại Xiaomi. Poco 4 đã được hoàn thiện trong quá trình sản xuất và đưa ra thị trường sau một thời gian dài, chắc chắn sẽ không khiến người dùng thất vọng về cả giá tiền và chất lượng mà máy mang lại." +
                     "<br><br>",
                    Content = "Xiaomi Poco F4 sẽ có các phiên bản RAM lớn giúp người dùng lưu trữ nhiều thông tin, không lo lắng nhanh hết dung lượng khi đang sử dụng. Với bộ nhớ dung lượng lớn, có hai phiên bản 8GB/128GB và 12GB/256GB." +
                     "<br><br>" +
                     comonFunction.ImageTag("cdn.mobilecity.vn/mobilecity-vn/images/2022/06/xiaomi-poco-f4-2.jpg.webp") +
                     "Xiaomi Poco F4 còn có thời lượng pin 4,500 mAh, người dùng tha hồ lướt web, chơi game giải trí hay làm việc cả một ngày dài mà không lo lắng hết pin giữa chừng, bên cạnh đó sản phẩm còn kết hợp hỗ trợ sạc nhanh lên đến 67W để sạc pin ngay khi cần đến." +
                     "<br><br>" +
                     "Sản phẩm Xiaomi Poco F4 được hoàn thiện dần và với tần số quét lên đến 120Hz, Sử dụng tấm nền AMOLED tạo khả năng tối sử khi chơi game, hiệu ứng chuyển cảnh nhanh chóng, hứa hẹn sẽ mang đến cho người sử dụng những giây phút mượt mà, nhanh chóng hơn khi chiến trong game hay nghe nhạc, xem phim." +
                     "<br><br>" +
                     comonFunction.ImageTag("cdn.mobilecity.vn/mobilecity-vn/images/2022/06/xiaomi-poco-f4-8.JPG.webp") +
                     "POCO F4 có độ phân giải full HD+, tốc độ nhanh nhạy khiến người dùng phải kinh ngạc bởi đồ họa chân thực, sống động với màn hình khá rộng. Kết hợp với con chip tầm trung mạnh mẽ, hiệu suất cao tạo trải nghiệm tốt nhất dành đến cho người dùng." +
                     "<br><br>" +
                     "Cả 2 phiên bản POCO F4 (6GB/128GB) và (8GB/256GB) đều được trang bị chipset Snapdragon 8 Gen 1 nên có thể cho phép chơi game tốt mà không giật, lag. Tuy nhiên thời lượng pin 4,500 mAh là khá khiêm tốn khi gaming.",
                    Hot = 1,
                    Photo = "Xiaomi Poco F4.webp",
                    Price = 8090000,
                    DiscountID = 1,
                    Amount = 50
                },
                // Add OPPO
                new Products
                {
                    ID = 24,
                    Name = "OPPO Reno8 5G 8GB 256GB",
                    CategoryID = 4,
                    Decription = "Oppo Reno8 5G sở hữu con chip MediaTek Dimensity 1300 5G cùng dung lượng RAM lên đến 8GB mang đến hiệu suất xử lý vô cùng mạnh mẽ. Với camera chính 50MP cùng hai cảm biến phụ ở mặt lưng, smartphone sẽ giúp bạn lưu lại những bức ảnh sắc nét. Thiết bị cũng thu hút sự chú ý bởi màn hình 6.43 inch AMOLED có độ phân giải Full HD+." +
                    "<br><br>",
                    Content = "Với thiết kế cụm camera số 8 nhấn mạnh 8 tiếng tận hưởng mỗi ngày. Thay vì sống một cuộc sống gò bó, chỉ tập trung vào công việc như một robot được lập trình sẵn, hay chia thời gian mỗi ngày thành 3 phần: 8 tiếng làm việc, 8 tiếng tận hưởng và 8 tiếng nghỉ ngơi." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/263714/Slider/OPPO-Reno8-5G-slide-1a-1020x570.jpg") +
                    "Sau thời gian làm việc hãy tập trung hoàn toàn cho các trải nghiệm cá nhân, tận hưởng các cuộc sống thú vị về ban đêm. OPPO Reno8 với camera siêu cảm biến giúp ghi lại những khoảng khắc đáng nhớ một cách rõ nét. Khung giờ cuối cùng là 8 tiếng để nghỉ ngơi, bổ sung năng lượng với chế độ sạc đêm an toàn." +
                    "<br><br>" +
                    "Oppo Reno8 5G đã thu hút rất nhiều sự chú ý từ các tín đồ công nghệ ngay từ những ngày đầu ra mắt. Được đầu tư vào ngoại hình vô cùng “trendy” với bộ cấu hình vượt trội, smartphone là sự lựa chọn hoàn hảo ở phân khúc giá tầm trung. Điểm nhấn ở thế hệ Reno8 này nằm ở hiệu suất vượt trội, màn hình AMOLED đẹp mắt và viên pin khổng lồ." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/263714/Slider/oppo-reno8-hieu-nang-1020x570.jpg") +
                    "Dòng Oppo Reno8 5G được hãng chú trọng khá nhiều về phần thiết kế khi được chế tác từ chất liệu kính cao cấp, có khả năng chống nước và bụi bẩn IP54. Khác với thế hệ Reno7 ở đời trước, chiếc smartphone đã được nâng cấp với các đường nét vuông vức và “trendy”. Hiện nay, dòng Reno8 5G cung cấp ba phiên bản màu là đen, xanh dương và vàng.\r\n\r\n" +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/263714/Slider/oppo-reno8-5g--3--1020x570.jpg") +
                    "Ngài hiệu suất xử lý mạnh mẽ, máy còn được trang bị đến 8GB RAM giúp bạn có thể thực hiện cùng lúc nhiều tác vụ. Ở thế hệ Reno8, Oppo còn tích hợp thêm 5GB RAM ảo để bạn có thể kích hoạt trong trường hợp muốn nâng cấp hiệu suất của máy. Trên hết, Reno8 mang đến bộ nhớ khổng lồ với dung lượng đến 256GB cho bạn thoải mái lưu trữ mọi dữ liệu.",
                    Hot = 1,
                    Photo = "OPPO Reno8 5G 8GB 256GB.webp",
                    Price = 8090000,
                    DiscountID = 1,
                    Amount = 50
                },
                new Products
                {
                    ID = 25,
                    Name = "OPPO Find N2 Flip",
                    CategoryID = 4,
                    Decription = "OPPO Find N2 Flip dự kiến sẽ là chiếc điện thoại khiến nhiều tín đồ công nghệ quan tâm khi sở hữu thiết kế bắt mắt, cùng màn hình ấn tượng. Đi cùng với đó là hệ thống camera của thiết bị cũng cao cấp không kém khi tích hợp đầy đủ các cảm biến, cùng đa dạng tính năng chụp ảnh." +
                    "<br><br>",
                    Content = "Trên thị trường hiện tại, các dòng điện thoại Flip đa số vẫn chưa giải quyết được vấn đề nếp nhăn xuất hiện ở phần màn hình gập. Tuy nhiên đến với OPPO Find N2 Flip, bạn sẽ có được trải nghiệm hoàn toàn mới – GẬP KHÔNG NẾP GẤP. Tất cả là nhờ vào bản lề cao cấp có độ bền 10 năm được chế tạo từ vật liệu chuyên dụng trong ngành hàng không. Đây chính là thành quả đột phá của quá trình nghiên cứu và phát triển của OPPO trong suốt 5 năm đối với dòng điện thoại gập." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/299034/oppo-find-n2-flip-150223-051048.jpg") +
                    "Ngoài ra, OPPO Find N2 Flip sẽ sở hữu hai màn hình với kích thước, cùng những thông số về cấu hình khác nhau. Theo đó màn hình phụ kích thước 3.26 inch rộng rãi, tấm nền AMOLED, tần số quét 60Hz, cùng độ phân giải 720x382. Nhờ vậy, bạn có thể xem được các thông báo một cách liền mạch, trực quan và sắc nét hơn. Đồng thời, các phím tắt ở màn hình này được tích hợp vào nhằm hỗ trợ tùy chỉnh nhanh và tiết kiệm thời gian." +
                    "<br><br>" +
                    "Màn hình chính của thiết bị sẽ có kích thước là 6.8 inch, với cùng một tấm nền AMOLED và tần số 120Hz. Tuy nhiên, độ phân giải của màn hình lớn sẽ có một chút khác biệt là Full HD+." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/299034/Slider/oppo-find-n2-flip638164614936691947.jpg") +
                    "Ở mỗi màn hình trong và ngoài của smartphone đều được OPPO trang bị một chiếc camera selfie có độ phân giải 32MP. Như vậy, dù thiết bị đang được gập lại, hay mở ra, người dùng đều có thể chụp những bức ảnh selfie hay thực hiện cuộc gọi video." +
                    "<br><br>" +
                    "Cùng với đó, thiết bị còn được trang bị công nghệ cao cấp, bao gồm cảm biến Sony và bộ xử lý hình ảnh NPU mang tên MariSilicon X. Nhờ vậy, ảnh chụp trở nên rõ ràng sắc nét kể cả trong điều kiện ánh sáng kém. Hệ thống camera man đến cảm giác chân thực như đang thao tác trên máy ảnh Hasselblad. Từ âm thanh màn trập mang tính biểu tượng cho đến chế độ Xpan huyền thoại, thiết bị còn kết hợp bộ lọc màu Hasselblad cho cảm giác chân thực đáng kinh ngạc." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/299034/Slider/oppo-find-n2-flip638164614938261952.jpg") +
                    "OPPO Find N2 Flip sở hữu cụm camera: camera chính 50MP, camera góc siêu rộng 8MP và camera selfie 32MP. Nhờ độ phân giải cao, cảm biến đi kèm và công nghệ cao cấp mà người dùng có thể bắt trọn mọi khoảnh khắc trong cuộc sống hằng ngày một cách dễ dàng.",
                    Hot = 1,
                    Photo = "OPPO Find N2 Flip.webp",
                    Price = 19990000,
                    DiscountID = 1,
                    Amount = 50
                },
                new Products
                {
                    ID = 26,
                    Name = "OPPO A77s",
                    CategoryID = 4,
                    Decription = "Một trong số những đặc điểm nổi bật của OPPO A77 được giữ trong bản nâng cấp A77s chính là thiết kế thanh mảnh đậm vẻ hiện đại. Có kích thước là hình chữ nhật thuôn dài với chiều cao 163,8mm cùng chiều rộng 75mm, chiếc smartphone này giúp tối ưu khung hình hiển thị để mang đến cảm giác thoải mái nhất cho mắt." +
                     "<br><br>",
                    Content = "Độ dày chỉ khoảng 8mm cùng với trọng lượng chỉ 187gram, OPPO A77s mang đến cảm giác nhẹ như không khi cầm trên tay. Điều này cũng cực kỳ phù hợp với xu hướng điện thoại ngày càng mỏng nhẹ hiện tại và mang đến cảm giác cực kỳ thời thượng, hiện đại. Mặt trước của OPPO A77s được làm bằng kính có khả năng chịu lực và mắt sau được cấu thành từ vật liệu nhựa hoặc da giúp tối đa hóa độ bền của máy.  " +
                     "<br><br>" +
                     comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/292780/Slider/oppo-a77s-slider-1a-1020x570-1020x570.jpg") +
                     "Để mang đến hiệu quả tốt nhất cho các khung hình, OPPO có sự đầu tư lớn vào màn hình của A77s. Những chiến binh smartphone mới đến từ thương hiệu điện thoại này được trang bị tấm nền IPS LCD với độ sáng cao từ 480 - 600 nits. Nhờ điều này mà OPPO A77s có thể hiển thị sắc nét hình ảnh ngay cả khi phải hoạt động trong môi trường cường độ ánh sáng lớn." +
                     "<br><br>" +
                     comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/292780/Slider/oppo-a77s-slider-9--1--1020x570.jpg") +
                     "Khả năng cảm ứng của OPPO A77s cũng khá tốt với tốc độ quét 90Hz cùng tỷ lệ lấy mẫu cảm ứng 180Hz. So với kích thước tổng thể của cả điện thoại thì màn hình chiếm 84,2%. Đây không phải kích thước lý tưởng cho những chiếc điện thoại có màn hình tràn viền nhưng là kích thước hợp lý để tạo ra cảm giác thoải mái khi thực hiện các thao tác." +
                     "<br><br>" +
                     comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/292780/Slider/vi-vn-oppo-a77s-slider--(2).jpg") +
                     "Là một trong số những chiếc smartphone tầm trung được quan tâm bậc nhất thị trường nên cấu hình của OPPO A77s chẳng phải dạng vừa. Chiếc điện thoại này sở hữu hệ điều hành Android 12 tiên tiến cùng chipset Snapdragon 680 8 nhân mạnh mẽ." +
                     "<br><br>" +
                     "Với khả năng lưu trữ dữ liệu trong bộ nhớ chính 128GB cùng RAM 8GB chiếc điện thoại này sẵn sàng thách thức mọi thao tác đa nhiệm khó nhằn. OPPO A77s sẵn sàng phục vụ người dùng với tốc độ xử lý nhanh cùng thao tác mượt mà trên nền tảng công nghệ của mình.",
                    Hot = 1,
                    Photo = "OPPO A77s.webp",
                    Price = 19990000,
                    DiscountID = 1,
                    Amount = 50
                },
                // add  Nokia
                new Products
                {
                    ID = 27,
                    Name = "Nokia G22 4GB 128GB",
                    CategoryID = 5,
                    Decription = "Nokia G22 thu hút được sự chú ý của người dùng nhờ thiết kế cực kỳ nhỏ gọn, thanh lịch. Dù sở hữu một thông số hiệu năng ổn định - chip Unisoc T606, cùng các tính năng hiện đại khác nhưng G22 lại sở hữu một mức giá cực hấp dẫn, chỉ khoảng 4.5 triệu VND. Màn hình hiển thị HD+ mang lại chất lượng hình ảnh chân thật, sắc nét. Dung lượng Pin mà Nokia G22 sở hữu lên tới 5050 mAh cùng công suất sạc 20W. " +
                     "" +
                     "<br><br>",
                    Content = "Gần đây trên các diễn đàn công nghệ lớn thường rỉ tai nhau về sản phẩm smartphone sở hữu thông số mạnh mẽ chuẩn bị được ra mắt tới đây của Nokia - Nokia G22. Nhờ sở hữu những đột phá, nâng cấp mạnh mẽ về công nghệ, G22 được nhiều chuyên gia đánh giá rất cao và sẽ còn tạo được nhiều thành công vang dội hơn nữa trong tương lai. Vậy thiết bị công nghệ tới từ Nokia này có thực sự mạnh mẽ như vậy không? Cùng mình tìm hiểu Nokia G22 ngay nhé!" +
                     "<br><br>" +
                     comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/303937/Slider/nokia-g22-tong-quan-1c-1020x570.png") +
                     "Nokia G22 sở hữu mặt lưng được hoàn thiện từ 100% nhựa tái chế. Vật liệu này không chỉ giúp bảo vệ môi trường mà còn mang đến khả năng sử dụng bền bỉ. Điều đó cũng đồng nghĩa với việc người dùng có thể yên tâm sử dụng thiết bị lâu dài mà không cần lo bởi ảnh hưởng từ môi trường bên ngoài." +
                     "<br><br>" +
                     "Ngoài ra, khả năng sửa chữa QuickFix cũng là một trong những ưu điểm của Nokia G22.Với khả năng này, bạn hoàn toàn có thể dễ dàng tự thay thế các bộ phận bị hỏng. Như vậy, không cần phải đến trung tâm bảo hành hay cửa hàng, người dùng vẫn có thể sửa chữa được màn hình và pin. Có thể thấy thay vì phải mất nhiều thời gian và chi phí, bạn chỉ cần tham khảo iFixit để biết các bộ phận điện thoại, công cụ cần thiết và hướng dẫn thực hiện." +
                     "<br><br>" +
                     comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/303937/Slider/vi-vn-nokia-g22-slider--(5).jpg") +
                     "Nokia G22 trang bị camera sau độ phân giải lên đến 50MP, camera cảm biến chiều sâu 2MP, camera macro 2MP và camera selfie 8MP. Với bộ camera này, người dùng sẽ có thể chụp ảnh sắc nét và chân thực hơn bao giờ hết." +
                     "<br><br>" +
                     "Ngoài ra, thiết bị còn tích hợp công nghệ tập trung âm thanh OZO Audio tiên tiến. Với OZO, chất lượng âm thanh được nâng cao, tiếng ồn xung quanh cũng được giảm thiểu đáng kể. Như vậy, người dùng sẽ có những trải nghiệm thú vị khi giải trí cùng những bộ phim hấp dẫn hay hoà mình vào giai điệu âm nhạc." +
                     "<br><br>" +
                     comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/303937/Slider/vi-vn-nokia-g22-slider--(3).jpg") +
                     "Điện thoại Nokia G22 được kế thừa và phát huy những giá trị cốt lõi của các phiên bản tiền nhiệm, mang tới cho người dùng sự đơn giản nhưng không kém phần hiện đại, thanh lịch. Các thiết kế bo tròn mềm mại của cạnh, viền thân máy cho phép người dùng có thể cầm nắm sản phẩm một cách thoải mái, nhẹ nhàng hơn. " +
                     "<br>" +
                     "<br>" +
                     "So với phiên bản G21 với những đường vân ngang ở mặt lưng đã được ra mắt trước đó, Nokia G22 gây được ấn tượng với người dùng nhờ sở hữu thiết kế mặt lưng dạng nhám nhẹ. Ưu điểm này giúp G22 hạn chế bám dính vân tay của người dùng, giữ máy luôn ở trong tình trạng tốt nhất. Hệ thống âm thanh, micro và phím nút tăng giảm âm lượng được bố trí đều quanh viền máy mang tới sự hài hòa tuyệt đối trong thiết kế nổi bật của Nokia G22." +
                     "<br>" +
                     "<br>" +
                     comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/303937/Slider/vi-vn-nokia-g22-slider--(2).jpg") +
                     "Trong sự kiện ra mắt của Nokia G22, sản phẩm có những sự mới mẻ về màu sắc hơn so với phiên bản tiền nhiệm: màu Meteor Grey và Lagoon Blue.  Nhờ vậy, người dùng cảm thấy thoải mái hơn trong quá trình chọn lựa tuỳ chọn màu sắc hợp với cá tính và phong cách của bản thân.",
                    Hot = 1,
                    Photo = "Nokia G22 4GB 128GB.webp",
                    Price = 3990000,
                    DiscountID = 1,
                    Amount = 50
                },
                new Products
                {
                    ID = 28,
                    Name = "Nokia C21 Plus 2GB 64GB",
                    CategoryID = 5,
                    Decription = "Nokia C21 Plus sở hữu bộ đôi camera sau 13MP+2MP. Trong đó, camera chính của điện thoại Nokia C21 Plus còn hỗ trợ thêm tính năng chụp góc rộng kèm theo tự động lấy nét giúp bạn có thể thỏa sức sáng tạo nên những bức ảnh bắt trọn nhiều khoảnh khắc đáng nhớ. Ngoài ra, camera phụ 2,P hỗ trợ chế độ chụp chân dung tạo nên những bức ảnh nghệ thuật đỉnh cao" +
                    "<br><br>",
                    Content = "C21 Plus mang trong mình viên pin có dung lượng 5050 mAh, bạn có thể sử dụng liên tục xuyên suốt cả ngày. Đi kèm với đó là chuẩn sạc Micro USB 10 W cơ bản, với công suất này thì bạn có thể sạc máy trong thời gian nghỉ ngơi để hạn chế thời gian chờ đợi." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/274084/Slider/1.-Tong-quan-(1)-1020x569.jpeg") +
                    "Nokia C21 Plus có một màn hình kích thước 6.5 inch, trang bị tấm nền TFT LCD kèm với độ phân giải HD+, đây là một chiếc màn hình có thông số khá cơ bản, hình ảnh hiển thị trên máy có độ nổi khối, không bị rỗ nhiều khi so với các đối thủ trong tầm giá, phù hợp với các nhu cầu cơ bản của đại đa số người dùng hiện nay." +
                    "<br>" +
                    "<br>" +
                    "Nokia vẫn sử dụng cùng một ngôn ngữ thiết kế cho các sản phẩm ra mắt gần đây. C21+ sử dụng khung viền hợp kim nhôm cùng mặt lưng làm từ nhựa. Máy sở hữu kiểu thiết kế dạng vân, tạo cho mình một cảm giác cầm vào rất thích cũng như hạn chế bám dấu vân tay và mồ hôi tay trong quá trình sử dụng. Đồng thời sự chắc chắn mà máy mang lại cũng là yếu tố kiên quyết làm nên sức hấp dẫn của những chiếc điện thoại Nokia." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/274084/Slider/nokia-c21-plus637909285657080279.jpg") +
                    "Cụm camera sau của máy đặt ở bên trái của mặt lưng, chứa các cảm biến và được thiết kế theo hình chữ nhật, bo cong 4 góc đây là thiết kế đặc trưng của điện thoại Nokia trong thời gian gần đây." +
                    "<br><br>" +
                    "C21+ là chiếc điện thoại có cảm biến vân tay đặt ở mặt lưng, khi mình sử dụng thì tốc độ mở khóa khá nhanh và thao tác rất dễ chỉ với một cú chạm, do máy có màn hình khá lớn nên những bạn có bàn tay nhỏ cần phải đưa tay lên cao một tí để chạm đúng vùng cảm biến." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/274084/Slider/nokia-c21-plus637909285663910283.jpg") +
                    "Điện thoại trang bị bộ vi xử lý SC9863A 8 lõi với tốc độ xung nhịp tối đa 1.6 GHz, đi cùng RAM 3 GB và bộ nhớ trong 64 GB, có một khe cắm thẻ nhớ MicroSD cho người dùng nâng cấp dung lượng bộ nhớ tối đa 256 GB." +
                    "<br><br>" +
                    "Nokia C21 Plus được cài đặt hệ điều hành Android 11 phiên bản Go, đem đến một giao diện thân thiện, dễ dàng thao tác và rất phù hợp với các bậc phụ huynh cũng như với ai mới tiếp cận với điện thoại thông minh." +
                    "<br><br>" +
                    comonFunction.ImageTag("cdn.tgdd.vn/Products/Images/42/274084/Slider/nokia-c21-plus637909285654390264.jpg") +
                    "Với những điểm nổi bật kể trên Nokia C21 Plus quả là một lựa chọn hoàn hảo trong phân khúc điện thoại giá rẻ khi mang trong mình một viên pin khủng, hệ điều hành mượt mà và màn hình kích thước lớn.",
                    Hot = 1,
                    Photo = "Nokia C21 Plus 2GB 64GB.webp",
                    Price = 3990000,
                    DiscountID = 1,
                    Amount = 50
                }

                );

        }
    }
}
