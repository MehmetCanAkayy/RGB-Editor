# RGB-Editor
Görüntü editörünün içeriğinde RGB kanallarının ayrı şekillerde gösterilmesi.Verilen görüntünün Yatay ve Dikey olarak aynalanmış şekilde
gösterilmesi.Görüntünün alçak geçiren filtre ile detayların yakalanması.
Görüntünün yatay ve dikey kenarlarının bulunması.Bunların hepsi kullanıcı arayüzünde gösterilecek şekilde oluşturulmuştur.

![image](https://user-images.githubusercontent.com/24396577/54498073-56254480-4913-11e9-9f36-8a5f7d862179.png)

**Sobel Algoritması ile Kenar Bulunması** <br/>

Görüntüyü siyah beyaza çevirdikten sonra kenar bulma algoritmalarısı olarak sobelini filtresi kullanılmıştır.Aşağıdaki çekirdek matrisler (konvolüsyon matrisleri) dikey, yatay ve köşegen şeklindeki kenarları bulmak için
kullanılır. Sobel operatörü bir resmin kenarlarına karşılık gelen alansal yüksek frekans bölgelerini (keskin kenarları) ortaya çıkarır.
Teorik olarak, operatör aşağıda gösterildiği gibi 3×3 konvolüsyon matrisinden oluşur.

![image](https://user-images.githubusercontent.com/24396577/54497970-1b6edc80-4912-11e9-8f8f-5d9d219e4196.png)

Bu matrisler, yatay ve dikey olarak çalışan kenarlara en üst düzeyde yanıt vermek için tasarlanmıştır. Matrisler giriş görüntüsüne ayrı ayrı uygulanabilir. Böylece her bir yön için pikselin değeri ayrı ayrı ölçülmüş olur.
Daha sonra bu değerler her bir noktada mutlak büyüklüğü ve yönü bulmak üzere birleştirilebilir. Bu gradyan değerlerinin vektör toplamları, gradyan ölçümlerinin yönü (directions of measurement) üzerinde ortalama değerin bulunmasını sağlar.
Eğer yoğunluk fonksiyonu gerçekten düzlemsel ise, o noktanın etrafındaki bütün yakın komşuluklardaki tüm gradyanlar aynı değere sahip olur.

![image](https://user-images.githubusercontent.com/24396577/54497619-d8ab0580-490d-11e9-9933-58183b52014f.png)

**Gaussian Alçak Geçiren Algoritması** <br/>
Filtreleme işlemlerinin en temel olanı "düşük geçiş" olarak adlandırılır. Aynı zamanda "bulanıklaştırma" veya "düzleştirme" filtresi olarak da adlandırılan düşük geçişli bir filtre, yoğunluktaki hızlı değişimlerin ortalamasını alır. 
En basit alçak geçirgen filtre yalnızca bir pikselin ve onun sekiz komşusunun ortalamasını hesaplar. Sonuç, pikselin orijinal değerini değiştirir. İşlem görüntüdeki her piksel için tekrarlanır.
Genellikle görüntüler gürültülü olabilir - kamera ne kadar iyi olursa olsun, görüntüye her zaman bir miktar “kar” ekler. Işığın istatistiksel niteliği de görüntüye gürültüye katkıda bulunur. Bu nedenle, düşük geçişli bir filtre, bazen gürültüyle boğulmuş hafif ayrıntıları ortaya çıkarmak için kullanılabilir.
Bitişik pikselleri ortalamaya alarak düşük geçişli bir filtre gerçekleştirmek için aşağıdaki çekirdek kullanılır.

![image](https://user-images.githubusercontent.com/24396577/54498010-8a4c3580-4912-11e9-9110-132d57de3afc.png)

**RGB Kanallarına Ayırma** <br/>

![image](https://user-images.githubusercontent.com/24396577/54497623-eb253f00-490d-11e9-8648-f597c73c35e7.png)

**Yatay Aynalama** <br/>

![MirrorImage3](https://user-images.githubusercontent.com/24396577/54498387-b9b17100-4917-11e9-981e-fbd8600ae945.png)

**Dikey Aynalama** <br/>

![image](https://user-images.githubusercontent.com/24396577/54498411-fa10ef00-4917-11e9-82a0-362eac943b0e.png)
