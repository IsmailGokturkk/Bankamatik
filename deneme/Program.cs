using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Bankamatik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int anaPara = 2500;
            string password = "ab18";

        MENU:
            try
            {
                Console.WriteLine("Hoş geldiniz\nLütfen yapmak istediğiniz işlemi seçiniz:\nKartlı işlem için 1'i\nKartsız işlem için 2'i seçiniz");
                string kartSecim = Console.ReadLine();

                if (kartSecim == "1")
                {

                    int sifreHak = 2;

                SIFREMENU:
                    Console.WriteLine("\n\nLütfen şifrenizi giriniz");
                    string sifre = (Console.ReadLine());


                    if (password == sifre)
                    {
                    ANAMENU:
                        Console.WriteLine("\n\nLütfen yapmak istediğiniz işlemi seçiniz:Para çekmek için 1\nPara yatırmak için 2\nPara transferi için 3\nEğitim ödemeleri için 4\nÖdemeler için 5\nBilgi düzenleme için 6");
                        string yapılacakIslem = Console.ReadLine();

                        if (yapılacakIslem == "1")
                        {
                        PARACEKME:
                            try
                            {
                                Console.WriteLine("\n\nÇekmek istediğiniz tutarı giriniz");
                                int cekilecekTutar = Convert.ToInt32(Console.ReadLine());

                                if (cekilecekTutar <= anaPara)
                                {
                                    Console.WriteLine("\nPara çekilmesi başarıyla tamamlandı");
                                    anaPara = anaPara - cekilecekTutar;
                                    Console.WriteLine("Güncel bakiyeniz=" + anaPara);
                                }
                                else
                                {
                                    Console.WriteLine("\nYetersiz bakiye,Lütfen geçerli tutar giriniz");
                                    goto PARACEKME;
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Hatalı karakter girişi\nLütfen geçerli karakter giriniz");
                                goto PARACEKME;
                            }

                        ISLEM1:
                            Console.WriteLine("\nÇıkış yapmak için 0'ı\nAna menüye dönmek için 9'a basınız");
                            string menuSecim = Console.ReadLine();
                            if (menuSecim == "0")
                            {
                                goto MENU;
                            }
                            else if (menuSecim == "9")
                            {
                                goto ANAMENU;
                            }
                            else
                            {
                                Console.WriteLine("\nLütfen geçerli işlem seçiniz");
                                goto ISLEM1;
                            }
                        }
                        else if (yapılacakIslem == "2")

                        {
                        ISLEM2:
                            Console.WriteLine("\n\nLütfen paranızı nereye yatırmak istediğinizi seçiniz\nKredi kartı için 1\nHesabınız için 2\n\nÇıkış yapmak için 9\nAna menüye dönmek için 0");
                            string yatırılacakYer = Console.ReadLine();
                            if (yatırılacakYer == "1")
                            {
                            KARTNUMARA:
                                try
                                {
                                    Console.WriteLine("\nLütfen kredi kartı numaranızı giriniz");
                                    long kartNumarası = Convert.ToInt64(Console.ReadLine());


                                    if (kartNumarası < 1000000000000 && kartNumarası > 99999999999)
                                    {
                                    KARTYATIRMA:
                                        try
                                        {
                                            Console.WriteLine("\nKredi kartına yatırmak istediğiniz tutarı giriniz");
                                            int kartYatırılacak = Convert.ToInt32(Console.ReadLine());


                                            if (anaPara >= kartYatırılacak)
                                            {
                                                anaPara = anaPara - kartYatırılacak;
                                                Console.WriteLine("\nPara kredi kartınıza yüklendi,Hesabınızdaki para=" + anaPara);


                                            ISLEM6:
                                                Console.WriteLine("\nÇıkış yapmak için 0'ı\nAna menüye dönmek için 9'a basınız");
                                                string menuSecim = Console.ReadLine();
                                                if (menuSecim == "0")
                                                {
                                                    goto MENU;
                                                }
                                                else if (menuSecim == "9")
                                                {

                                                    goto ANAMENU;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nLütfen geçerli işlem seçiniz");
                                                    goto ISLEM6;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nMevcut tutar=" + anaPara);
                                                Console.WriteLine("Lütfen geçerli tutar giriniz");
                                            ISLEM7:
                                                Console.WriteLine("\nYeni tutar girmek için 1\nÇıkış yapmak için 0'ı\nAna menüye dönmek için 9'a basınız");
                                                string menuSecim = Console.ReadLine();
                                                if (menuSecim == "0")
                                                {
                                                    goto MENU;
                                                }
                                                else if (menuSecim == "9")
                                                {
                                                    goto ANAMENU;
                                                }
                                                else if (menuSecim == "1")
                                                {
                                                    goto KARTYATIRMA;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nLütfen geçerli işlem seçiniz");
                                                    goto ISLEM7;
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Hatalı karakter girişi\nLütfen geçerli karakter giriniz");
                                            goto KARTYATIRMA;
                                        }
                                    }

                                    else
                                    {
                                        Console.WriteLine("\nLütfen geçerli kart numarası giriniz");
                                        goto KARTNUMARA;
                                    }
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Hatalı karakter girişi\nLütfen geçerli karakter giriniz");
                                    goto KARTNUMARA;
                                }

                            }
                            else if (yatırılacakYer == "2")
                            {
                            HYATIRMA:
                                try
                                {
                                    Console.WriteLine("\nLütfen hesabınıza yatırmak istediğiniz tutarı giriniz");
                                    int hParayatırma = Convert.ToInt32(Console.ReadLine());

                                    anaPara = anaPara + hParayatırma;
                                    Console.WriteLine("İşlem başarılı bakiyeniz=" + anaPara);

                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Hatalı karakter girişi\nLütfen geçerli karakter giriniz");
                                    goto HYATIRMA;
                                }
                                goto ISLEM2;
                            }
                            else if (yatırılacakYer == "9")
                            {
                                goto ANAMENU;
                            }
                            else if (yatırılacakYer == "0")
                            {
                                goto MENU;
                            }
                            else
                            {
                                Console.WriteLine("\nLütfen geçerli işlem seçiniz");
                                goto ISLEM2;
                            }

                        }
                        else if (yapılacakIslem == "3")
                        {
                            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz:\nBaşka hesaba EFT için 1\nBaşka hesaba HAVALE için 2");
                            string paraGonderme = Console.ReadLine();
                            if (paraGonderme == "1")
                            {
                            EFTGONDERME:
                                Console.WriteLine("Lütfen başında TR olucak şekilde" + " EFT numarasını giriniz");
                                string eftnumarası = Console.ReadLine();
                                int eftnumarası1 = eftnumarası.Length;
                                string eftnumarası2 = eftnumarası.Substring(0, 2);


                                if (eftnumarası1 >= 14 && eftnumarası2 == "TR")
                                {
                                EFTislem:
                                    try
                                    {
                                        Console.WriteLine("Lütfen göndermek istediğin tutarı gir");
                                        int EFTtutar = Convert.ToInt32(Console.ReadLine());
                                        if (EFTtutar <= anaPara)
                                        {
                                            anaPara = anaPara - EFTtutar;
                                            Console.WriteLine("İşlem başarılı\nMevcut bakiyeniz" + anaPara);

                                        ISLEM2:
                                            Console.WriteLine("\nÇıkış yapmak için 0'ı\nAna menüye dönmek için 9'a basınız");
                                            string menuSecim = Console.ReadLine();
                                            if (menuSecim == "0")
                                            {
                                                goto MENU;
                                            }
                                            else if (menuSecim == "9")
                                            {
                                                goto ANAMENU;
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nLütfen geçerli işlem seçiniz");
                                                goto ISLEM2;
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("Lütfen geçerli tutar giriniz.\nMevcut bakiyeniz=" + anaPara);

                                        ISLEM3:
                                            Console.WriteLine("\nYeni tutar girmek için 1\nÇıkış yapmak için 0'ı\nAna menüye dönmek için 9'a basınız");
                                            string menuSecim = Console.ReadLine();
                                            if (menuSecim == "0")
                                            {
                                                goto MENU;
                                            }
                                            else if (menuSecim == "9")
                                            {
                                                goto ANAMENU;
                                            }
                                            else if (menuSecim == "1")
                                            {
                                                goto EFTislem;
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nLütfen geçerli işlem seçiniz");
                                                goto ISLEM3;
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Hatalı karakter girişi\nLütfen geçerli karakter giriniz");
                                        goto EFTislem;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Lütfen geçerli bir EFT numarası giriniz");
                                ISLEM5:
                                    Console.WriteLine("\nYeni bir numara girmek için 1\nÇıkış yapmak için 0'ı\nAna menüye dönmek için 9'a basınız");
                                    string menuSecim = Console.ReadLine();
                                    if (menuSecim == "0")
                                    {
                                        goto MENU;

                                    }
                                    else if (menuSecim == "9")
                                    {
                                        goto ANAMENU;
                                    }
                                    else if (menuSecim == "1")
                                    {
                                        goto EFTGONDERME;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nLütfen geçerli işlem seçiniz");
                                        goto ISLEM5;
                                    }
                                }
                            }
                            else if (paraGonderme == "2")
                            {
                            HAVALE1:
                                try
                                {
                                    Console.WriteLine("Lütfen hesap numarasını giriniz");
                                    long HAVALE = Convert.ToInt64(Console.ReadLine());

                                    if (HAVALE > 9999999999 && HAVALE < 10000000000001)
                                    {
                                    ISTENILENTUTAR:
                                        Console.WriteLine("Lütfen göndermek istedğiniz tutarı giriniz");
                                        int HAVALE1 = Convert.ToInt32(Console.ReadLine());

                                        if (HAVALE1 <= anaPara)
                                        {

                                            anaPara = anaPara - HAVALE1;

                                            Console.WriteLine("İşlem başarılı\nMevcut bakiyeniz=" + anaPara);

                                        ISLEM4:
                                            Console.WriteLine("\nÇıkış yapmak için 0'ı\nAna menüye dönmek için 9'a basınız");
                                            string menuSecim = Console.ReadLine();
                                            if (menuSecim == "0")
                                            {
                                                goto MENU;

                                            }
                                            else if (menuSecim == "9")
                                            {

                                                goto ANAMENU;
                                            }

                                            else
                                            {
                                                Console.WriteLine("\nLütfen geçerli işlem seçiniz");
                                                goto ISLEM4;
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("Geçersiz tutar\nMevcut tutar=" + anaPara);
                                        ISLEM8:
                                            Console.WriteLine("\nYeni bir numara girmek için 1\nÇıkış yapmak için 0'ı\nAna menüye dönmek için 9'a basınız");
                                            string menuSecim = Console.ReadLine();
                                            if (menuSecim == "0")
                                            {
                                                goto MENU;

                                            }
                                            else if (menuSecim == "9")
                                            {
                                                goto ANAMENU;
                                            }
                                            else if (menuSecim == "1")
                                            {
                                                goto ISTENILENTUTAR;
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nLütfen geçerli işlem seçiniz");
                                                goto ISLEM8;
                                            }
                                        }
                                    }
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Lütfen geçerli bir karakter giriniz");
                                    goto HAVALE1;
                                }
                            }


                        }
                        else if (yapılacakIslem == "4")
                        {
                            Console.WriteLine("Eğitim ödemeleri sayfası bakım nedeniyle kapalıdır");

                        ISLEM8:
                            Console.WriteLine("\nÇıkış yapmak için 0'ı\nAna menüye dönmek için 9'a basınız");
                            string menuSecim = Console.ReadLine();
                            if (menuSecim == "0")
                            {
                                goto MENU;
                            }
                            else if (menuSecim == "9")
                            {
                                goto ANAMENU;
                            }
                            else
                            {
                                Console.WriteLine("\nLütfen geçerli işlem seçiniz");
                                goto ISLEM8;
                            }
                        }
                        else if (yapılacakIslem == "5")
                        {
                        ODEMELER1:
                            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçin:\nElektrik farturası ödeme için 1\nTelefon farturası ödeme için 2\nİnternet farturası ödeme için 3\nElektrik farturası ödeme için 1\nSu farturası ödeme için 4\nOGS ödemesi için 5\n");
                            string odemeler = Console.ReadLine();
                            if (odemeler == "1")
                            {
                            EFATURA:
                                try
                                {

                                    Console.WriteLine("Lütfen fatura tutarını giriniz");
                                    int elektrikFatura = Convert.ToInt32(Console.ReadLine());
                                    if (elektrikFatura <= anaPara)
                                    {
                                        anaPara = anaPara - elektrikFatura;
                                        Console.WriteLine("Ödeme başarıyla tamamlandı\nMevcut bakiye=" + anaPara);
                                    }

                                    else
                                    {
                                        Console.WriteLine("Lütfen geçerli tutar giriniz\nMevcut bakiyeniz=" + anaPara);
                                    }

                                ISLEM8:
                                    Console.WriteLine("\nYeni bir tutar girmek için 1\nÇıkış yapmak için 0'ı\nAna menüye dönmek için 9'a basınız");
                                    string menuSecim = Console.ReadLine();
                                    if (menuSecim == "0")
                                    {
                                        goto MENU;
                                    }
                                    else if (menuSecim == "9")
                                    {
                                        goto ANAMENU;
                                    }
                                    else if (menuSecim == "1")
                                    {
                                        goto EFATURA;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nLütfen geçerli işlem seçiniz");
                                        goto ISLEM8;

                                    }
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Hatalı karakter girişi\nLütfen geçerli karakter giriniz");
                                    goto EFATURA;
                                }
                            }
                            else if (odemeler == "2")
                            {

                            TFATURA:
                                try
                                {
                                    Console.WriteLine("Lütfen fatura tutarını giriniz");
                                    int telefonFatura = Convert.ToInt32(Console.ReadLine());
                                    if (telefonFatura <= anaPara)
                                    {
                                        anaPara = anaPara - telefonFatura;
                                        Console.WriteLine("Ödeme başarıyla tamamlandı\nMevcut bakiye=" + anaPara);

                                    }
                                    else
                                    {
                                        Console.WriteLine("Lütfen geçerli tutar giriniz\nMevcut bakiyeniz=" + anaPara);
                                    }

                                ISLEM8:
                                    Console.WriteLine("\nYeni bir tutar girmek için 1\nÇıkış yapmak için 0'ı\nAna menüye dönmek için 9'a basınız");
                                    string menuSecim = Console.ReadLine();
                                    if (menuSecim == "0")
                                    {
                                        goto MENU;
                                    }
                                    else if (menuSecim == "9")
                                    {
                                        goto ANAMENU;
                                    }
                                    else if (menuSecim == "1")
                                    {
                                        goto TFATURA;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nLütfen geçerli işlem seçiniz");
                                        goto ISLEM8;
                                    }
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Hatalı karakter girişi\nLütfen geçerli karakter giriniz");
                                    goto TFATURA;
                                }

                            }
                            else if (odemeler == "3")
                            {

                            IFATURA:
                                try
                                {
                                    Console.WriteLine("Lütfen fatura tutarını giriniz");
                                    int internetFatura = Convert.ToInt32(Console.ReadLine());
                                    if (internetFatura <= anaPara)
                                    {
                                        anaPara = anaPara - internetFatura;
                                        Console.WriteLine("Ödeme başarıyla tamamlandı\nMevcut bakiye=" + anaPara);

                                    }
                                    else
                                    {
                                        Console.WriteLine("Lütfen geçerli tutar giriniz\nMevcut bakiyeniz=" + anaPara);
                                    }

                                ISLEM8:
                                    Console.WriteLine("\nYeni bir tutar girmek için 1\nÇıkış yapmak için 0'ı\nAna menüye dönmek için 9'a basınız");
                                    string menuSecim = Console.ReadLine();
                                    if (menuSecim == "0")
                                    {
                                        goto MENU;
                                    }
                                    else if (menuSecim == "9")
                                    {
                                        goto ANAMENU;
                                    }
                                    else if (menuSecim == "1")
                                    {
                                        goto IFATURA;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nLütfen geçerli işlem seçiniz");
                                        goto ISLEM8;
                                    }

                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Hatalı karakter girişi\nLütfen geçerli karakter giriniz");
                                    goto IFATURA;
                                }
                            }
                            else if (odemeler == "4")
                            {

                            SFATURA:
                                try
                                {
                                    Console.WriteLine("Lütfen fatura tutarını giriniz");
                                    int suFatura = Convert.ToInt32(Console.ReadLine());
                                    if (suFatura <= anaPara)
                                    {
                                        anaPara = anaPara - suFatura;
                                        Console.WriteLine("Ödeme başarıyla tamamlandı\nMevcut bakiye=" + anaPara);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Lütfen geçerli tutar giriniz\nMevcut bakiyeniz=" + anaPara);
                                    }

                                ISLEM8:
                                    Console.WriteLine("\nYeni bir tutar girmek için 1\nÇıkış yapmak için 0'ı\nAna menüye dönmek için 9'a basınız");
                                    string menuSecim = Console.ReadLine();
                                    if (menuSecim == "0")
                                    {
                                        goto MENU;
                                    }
                                    else if (menuSecim == "9")
                                    {
                                        goto ANAMENU;
                                    }
                                    else if (menuSecim == "1")
                                    {
                                        goto SFATURA;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nLütfen geçerli işlem seçiniz");
                                        goto ISLEM8;
                                    }
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Hatalı karakter girişi\nLütfen geçerli karakter giriniz");
                                    goto SFATURA;
                                }
                            }
                            else if (odemeler == "5")
                            {

                            OGSFATURA:
                                try
                                {
                                    Console.WriteLine("Lütfen fatura tutarını giriniz");
                                    int ogsOdeme = Convert.ToInt32(Console.ReadLine());
                                    if (ogsOdeme <= anaPara)
                                    {
                                        anaPara = anaPara - ogsOdeme;
                                        Console.WriteLine("Ödeme başarıyla tamamlandı\nMevcut bakiye=" + anaPara);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Lütfen geçerli tutar giriniz\nMevcut bakiyeniz=" + anaPara);
                                    }

                                ISLEM8:
                                    Console.WriteLine("\nYeni bir tutar girmek için 1\nÇıkış yapmak için 0'ı\nAna menüye dönmek için 9'a basınız");
                                    string menuSecim = Console.ReadLine();
                                    if (menuSecim == "0")
                                    {
                                        goto MENU;

                                    }
                                    else if (menuSecim == "9")
                                    {
                                        goto ANAMENU;
                                    }
                                    else if (menuSecim == "1")
                                    {
                                        goto OGSFATURA;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nLütfen geçerli işlem seçiniz");
                                        goto ISLEM8;
                                    }
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Hatalı karakter girişi\nLütfen geçerli karakter giriniz");
                                    goto OGSFATURA;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Lütfen geçerli bir sayı giriniz");
                                goto ODEMELER1;
                            }
                        }
                        else if (yapılacakIslem == "6")
                        {
                        SIFREDEGISTIR:

                            Console.WriteLine("Lütfen şifre değiştirmek için 1 e basınız");
                            int sifreDegistirme = Convert.ToInt32(Console.ReadLine());

                            if (sifreDegistirme == 1)
                            {

                                Console.WriteLine("Lütfen yeni şifrenizi giriniz");
                                string yeniSifre = Console.ReadLine();

                                password = yeniSifre;

                                Console.WriteLine(password);

                            ISLEM8:
                                Console.WriteLine("\nÇıkış yapmak için 0'ı\nAna menüye dönmek için 9'a basınız");
                                string menuSecim = Console.ReadLine();
                                if (menuSecim == "0")
                                {
                                    goto MENU;
                                }
                                else if (menuSecim == "9")
                                {
                                    goto ANAMENU;
                                }
                                else
                                {
                                    Console.WriteLine("\nLütfen geçerli işlem seçiniz");
                                    goto ISLEM8;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Lütfen geçerli bir numara gitiniz");
                                goto SIFREDEGISTIR;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Lütfen 1 ile 6 arasında bir sayı seçiniz");
                            goto ANAMENU;
                        }
                    }
                    else
                    {
                        while (sifreHak > 0)
                        {
                            Console.WriteLine("Geçersiz Parola");
                            sifreHak--;
                            goto SIFREMENU;
                        }
                        Console.WriteLine("Hakkınız bitti");
                        System.Threading.Thread.Sleep(3000);
                        goto MENU;
                    }

                }
                else if (kartSecim == "2")
                {

                }
                else
                {
                    Console.WriteLine("Lütfen 1 veya 2 yazınız");
                    goto MENU;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı giriş yaptınız");
                goto MENU;
            }
            Console.ReadLine();
        }
    }
}
