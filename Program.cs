/*********************************************************************************** 
**                         SAKARYA ÜNİVERSİTESİ                                     **
**               BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ                          **         
**                 BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ BÖLÜMÜ                           **
**                    NESNEYE DAYALI PROGRAMLAMA DERSİ                              **
**                         2019-2020 BAHAR DÖNEMİ                                   **
**                                                                                  ** 
**        ÖDEV NUMARASI..........: 1                                                **
**        ÖĞRENCİ ADI............: ZEYNEP                                           **
**        ÖĞRENCİ NUMARASI.......: B181200009                                       **
**        DERSİN ALINDIĞI GRUP...: A                                                **
**                                                                                  **
***********************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banka_uygulaması
{
    class Program
    {
        static void Main(string[] args)
        {
            //Başlangıçta bakiye default olarak 15000 TL, parola ise 1234 olarak tanımlanmıştır.
            int bakiye = 15000, default_parola = 1234, parola = 0, para_cek = 0, para_yatir = 0, iban = 0, para_yolla = 0, secim;
            char sec;

        home:          //daha sonra en başa geri dönebilmek için home label'i ekliyoruz.

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(" CORONABANK bankasına hoşgeldiniz... ");
            Console.WriteLine("\n");
            Console.Write("Lütfen parolanızı giriniz: ");
            parola = Convert.ToInt32(Console.ReadLine());

            if (default_parola == parola) //parolanın doğruluğu test ediliyor.                         
            {

            BaskaIslem:   //goto metoduyla başa dönmek için bir label tanımlıyoruz.

                Console.Clear();
                Console.WriteLine(" 1.Şifre Değiştirme.\n 2.Para Çekme. \n 3.Para yatırma. \n 4.EFT/Havale. \n 5.Bakiye Sorgula.");
                Console.Write("Seçiminizi Yapın ve klavyeden Enter'a basın. : ");
                secim = Convert.ToInt32(Console.ReadLine());

                switch (secim)    //switch case kullanarak işlemlerin ayrı ayrı kodlarını yazıyoruz.
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Mevcut Şifrenizi Girin: ");
                        parola = Convert.ToInt32(Console.ReadLine());

                        if (default_parola == parola)                             //şimdiki parola kontrolü yapılıyor.
                        {
                            Console.Write("Yeni parolanızı giriniz: ");
                            default_parola = Convert.ToInt32(Console.ReadLine());           //yeni parola tanımlanıyor.
                            Console.WriteLine("Parola değiştirme işlemi başarılı...");
                            Console.Write("Başka işlem yapmak ister misiniz? (E/H) : ");
                            sec = Convert.ToChar(Console.ReadLine());

                            if (sec == 'E' || sec == 'e')
                            {
                                goto BaskaIslem;
                            }
                            else
                                break;
                        }

                        else
                        {
                            Console.Write("Parolanızı yanlış girdiniz. Tekrar denemek ister misiniz? (E/H) : ");
                            sec = Convert.ToChar(Console.ReadLine());

                            if (sec == 'E' || sec == 'e')        //parolanın yanlış girilmesi durumunda işleme devam için izin isteniyor.
                            {
                                goto case 1;
                            }

                            else
                            {
                                break;
                            }
                        }

                    case 2:
                        Console.Clear();
                        Console.Write("Çekmek istediğiniz tutarı girin: ");
                        para_cek = Convert.ToInt32(Console.ReadLine());

                        if (para_cek > bakiye)                     //çekilmek istenen tutarın bakiye ile karşılaştırılması yapılıyor.
                        {
                            Console.WriteLine("Bakiyeniz yetersiz.");
                            Console.WriteLine("lutfen gecerli bir tutar giriniz");
                            Console.ReadLine();

                            goto case 2;

                        }

                        else
                        {
                            bakiye = bakiye - para_cek;                  //para çekme işlemi yapılıyor.
                            Console.WriteLine("{0} TL para çekmek üzeresiniz, onaylıyor musunuz? (E/H) : ", para_cek);
                            sec = Convert.ToChar(Console.ReadLine());

                            if (sec == 'E' || sec == 'e')
                            {
                                Console.WriteLine("{0} TL tutarındaki para başarıyla çekilmiştir. ", para_cek);

                            }

                            else
                            {
                                goto BaskaIslem;            //else koşuluyla başka işlem yapmak için BaskaIslem label'ına geri dönüyoruz. 
                            }


                            Console.Write("Başka işlem yapmak ister misiniz? (E/H) : ");
                            sec = Convert.ToChar(Console.ReadLine());

                            if (sec == 'E' || sec == 'e')
                            {
                                goto BaskaIslem;
                            }

                            else
                                break;
                        }



                    case 3:

                        Console.Clear();
                        Console.Write("Yatırmak istediğiniz tutarı girin: ");
                        para_yatir = Convert.ToInt32(Console.ReadLine());
                        //para yatırma işlemi yapılıyor.
                        bakiye = bakiye + para_yatir;
                        Console.WriteLine("{0} TL yatirdiniz.", para_yatir);
                        Console.Write("Başka işlem yapmak ister misiniz? (E/H) : ");
                        sec = Convert.ToChar(Console.ReadLine());

                        if (sec == 'E' || sec == 'e')
                        {
                            goto BaskaIslem;
                        }

                        break;

                    case 4:

                        Console.Clear();
                        Console.WriteLine("EFT/Havale yapmak istediğiniz hesabın IBAN numarasını giriniz. ");
                        iban = Convert.ToInt32(Console.ReadLine());            //Eft işlemi için iban isteniyor.

                    yeniden_tutar_gir:

                        Console.WriteLine("\n Göndermek istediğiniz tutarı giriniz. \n");

                        para_yolla = Convert.ToInt32(Console.ReadLine());

                        if (para_yolla > bakiye)                //yollanacak yeterli para kontrolü yapılıyor.
                        {
                            Console.WriteLine("Bu işlem için yeterli bakiyeniz bulunmamaktadır.");
                            Console.WriteLine("Lutfen gecerli bir tutar giriniz.");

                            goto yeniden_tutar_gir;           //yetersiz bakiye durumunda yeni bakiye girmek için tekrar bakiye girişi isteniyor.

                        }



                        //yeterli bakiye girişi yapıldığında işlem yapılmak için izin isteniyor.

                        Console.WriteLine("{0} IBAN no'lu hesaba {1} TL yatırmak üzeresiniz. İşlemi onaylıyor musunuz? (E/H) : ", iban, para_yolla);

                        sec = Convert.ToChar(Console.ReadLine());

                        if (sec == 'E' || sec == 'e')
                        {
                            Console.WriteLine("{0} IBAN no'lu hesaba {1} TL tutarındaki para başarıyla aktarılmıştır. ", iban, para_yolla);
                            Console.Write("\nBaşka işlem yapmak ister misiniz? (E/H) : ");
                            sec = Convert.ToChar(Console.ReadLine());

                            if (sec == 'E' || sec == 'e')
                            {
                                goto BaskaIslem;
                            }

                        }

                        break;

                    case 5:

                        Console.Clear();                                            //burada bütün işlemlerden sonra en son durumdaki bakiye sorgulanıyor.
                        Console.WriteLine("Mevcut bakiyeniz: {0} TL", bakiye);
                        Console.Write("Başka işlem yapmak ister misiniz? (E/H) : ");
                        sec = Convert.ToChar(Console.ReadLine());

                        if (sec == 'E' || sec == 'e')
                        {
                            goto BaskaIslem;
                        }

                        else
                            break;


                }
            }

            else          //yukarıdaki if koşuluyla kontrol edilen parolanın yanlış olması durumunda ana menüye dönülüyor.
            {
                Console.Write("Parolanızı yanlış girdiniz. Tekrar denemek ister misiniz? (E/H) : ");
                sec = Convert.ToChar(Console.ReadLine());

                if (sec == 'E' || sec == 'e')
                {
                    goto home;
                }
            }


            Console.WriteLine("\n İyi günler dileriz. Yine bekleriz..."); Console.WriteLine("\n\n");
            Console.ReadKey();


        }
    }
}
