#

Lệnh tạo một chứng chỉ SSL tự kí mới cho các kịch bản phát triển hoặc kiểm thử
dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\TeaAPI.pfx -p pa55w0rd!
dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\Coffee.pfx -p pa55w0rd!

dotnet dev-certs https --trust

Cấu hình bí mật ứng dụng cho chứng chỉ
dotnet user-secrets set "Kestrel:Certificates:Development:Password" "pa55w0rd!"

tạo Certificate Signing Request (CSR).
openssl req -config https.config -new -out csr.pem

    openssl: Đây là công cụ dòng lệnh OpenSSL, được sử dụng rộng rãi cho các hoạt động mã hóa khác nhau.

    req: Lệnh con này được sử dụng để tạo và xử lý các yêu cầu ký chứng chỉ X.509 (CSR).

    -config https.config: Tùy chọn này chỉ định rằng cấu hình cho CSR phải được đọc từ tệp https.config. Tệp cấu hình chứa nhiều cài đặt và chi tiết khác nhau sẽ được đưa vào CSR.

    -new: Tùy chọn này chỉ định rằng CSR mới sẽ được tạo. Bạn không sử dụng lại CSR hiện có; thay vào đó, bạn đang tạo một cái mới.

    -out csr.pem: Tùy chọn này chỉ định tệp đầu ra nơi CSR được tạo sẽ được lưu. Trong trường hợp này, CSR sẽ được lưu dưới dạng csr.pem.

    Tóm lại, lệnh này tạo CSR mới bằng cách sử dụng cài đặt cấu hình được chỉ định trong tệp https.config và lưu CSR kết quả vào tệp csr.pem. CSR thường được sử dụng khi yêu cầu chứng chỉ kỹ thuật số từ Cơ quan cấp chứng chỉ (CA) hoặc khi tạo chứng chỉ tự ký. CSR chứa thông tin về thực thể yêu cầu chứng chỉ và khóa chung sẽ được sử dụng trong chứng chỉ.

tạo chứng chỉ X.509 tự kí
openssl x509 -req -days 365 -extfile https.config -extensions v3_req -in csr.pem -signkey key.pem -out https.crt

    openssl: Đây là công cụ dòng lệnh OpenSSL, được sử dụng rộng rãi cho các hoạt động mã hóa khác nhau.

    x509: Lệnh con này chỉ định rằng bạn đang làm việc với chứng chỉ X.509.

    -req: Tùy chọn này cho biết rằng bạn đang xử lý yêu cầu ký chứng chỉ (CSR). Bạn sẽ ký CSR này để tạo chứng chỉ.

    -days 365: Tùy chọn này chỉ định rằng chứng chỉ bạn đang tạo sẽ có hiệu lực trong 365 ngày (1 năm). Bạn có thể thay đổi giá trị này để đặt khoảng thời gian hiệu lực khác.

    -extfile https.config: Tùy chọn này chỉ định rằng các phần mở rộng cho chứng chỉ phải được lấy từ tệp https.config. Tiện ích mở rộng là các thuộc tính và ràng buộc bổ sung mà bạn có thể đưa vào chứng chỉ. Chúng được chỉ định trong tập tin cấu hình.

    -extensions v3_req: Tùy chọn này chỉ định phần trong tệp cấu hình (https.config) nơi xác định các tiện ích mở rộng cho chứng chỉ. Trong trường hợp này, chúng được xác định trong phần có tên [v3_req]. Phần này trong tệp cấu hình thường chứa các phần mở rộng X.509 tùy chỉnh.

    -in csr.pem: Tùy chọn này chỉ định tệp đầu vào csr.pem, là Yêu cầu ký chứng chỉ. Chứng chỉ sẽ được tạo dựa trên CSR này.

    -signkey key.pem: Tùy chọn này chỉ định tệp khóa riêng (key.pem) được sử dụng để ký CSR và tạo chứng chỉ. Cần có khóa riêng để chứng minh rằng bạn có quyền tạo chứng chỉ dựa trên CSR.

    -out https.crt: Tùy chọn này chỉ định tệp đầu ra nơi chứng chỉ X.509 được tạo sẽ được lưu. Trong trường hợp này, nó sẽ được lưu dưới dạng https.crt.

    Tóm lại, lệnh này đang lấy Yêu cầu ký chứng chỉ (csr.pem), ký nó bằng khóa riêng (key.pem) và tạo chứng chỉ X.509 tự ký (https.crt) với thời hạn hiệu lực là 365 ngày. Các phần mở rộng và chi tiết cho chứng chỉ được xác định trong tệp https.config, trong phần [v3_req]. Đây là cách điển hình để tạo chứng chỉ tự ký cho mục đích thử nghiệm và phát triển.
