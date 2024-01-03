using SinavTekrar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SinavTekrar.Views
{
    /// <summary>
    /// Interaction logic for OgrenciKayit.xaml
    /// </summary>
    public partial class OgrenciKayit : Window
    {
        public OgrenciKayit()
        {
            InitializeComponent();
            Db.Initalize();
            Listele();
            DbOgrenci.SelectionChanged += DbOgrenci_SelectionChanged;
        }

        private void DbOgrenci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DbOgrenci.SelectedItem != null)
            {
                Ogrenci selectedCategorys = DbOgrenci.SelectedItem as Ogrenci;
                TbOgrenciAdı.Text = selectedCategorys.Ad;
                TbOgrenciSoyadı.Text = selectedCategorys.Soyad;
                TbOgrenciNumarası.Text = selectedCategorys.Numara;
                TbOgrenciTarih.Text = selectedCategorys.Tarih;
                TbOgrenciAdres.Text = selectedCategorys.Adres;
            }
            else
            {
                // Eğer seçili öğe yoksa, alanları temizle veya isteğinize göre başka bir işlem yapabilirsiniz.
                TbOgrenciAdı.Text = "";
                TbOgrenciSoyadı.Text = "";
                TbOgrenciNumarası.Text = "";
                TbOgrenciTarih.Text = "";
                TbOgrenciAdres.Text = "";
            }
        }

        private void Listele()
        {
            var Ogrenciler=Db.Context.Ogrenciler.ToList();
            DbOgrenci.ItemsSource = Ogrenciler;
        }
        private void Bosalt()
        {
            TbOgrenciAdı.Text = "";
            TbOgrenciSoyadı.Text = "";
            TbOgrenciNumarası.Text = "";
            TbOgrenciTarih.Text = "";
            TbOgrenciAdres.Text = "";
        }
        private void BtnHepsiniSil_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ogrenciler = Db.Context.Ogrenciler.ToList();
                Db.Context.Ogrenciler.RemoveRange(ogrenciler);
                Db.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme İşlemi Başarısız.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            MessageBox.Show("Kategorilerin hepsi silindi", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
            Listele();
        }

        private void BtnEkle_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TbOgrenciAdı.Text) && string.IsNullOrWhiteSpace(TbOgrenciSoyadı.Text) && string.IsNullOrWhiteSpace(TbOgrenciNumarası.Text) 
                && string.IsNullOrWhiteSpace(TbOgrenciTarih.Text) && string.IsNullOrWhiteSpace(TbOgrenciAdres.Text))
            {
                MessageBox.Show("Lütfen Verileri Boş Bırakmayınız.", "Uyarı!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Ogrenci ogrenci = new Ogrenci()
            {
                Ad = TbOgrenciAdı.Text,
                Soyad = TbOgrenciSoyadı.Text,
                Numara = TbOgrenciNumarası.Text,
                Tarih = TbOgrenciTarih.Text,
                Adres = TbOgrenciAdres.Text
            };
            try
            {
                Db.Context.Ogrenciler.Add(ogrenci);
                Db.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                Db.Context.Ogrenciler.Add(ogrenci);
                MessageBox.Show("Kayıt Yapılırken Hata Oluştu.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Listele();
            Bosalt();
        }

        private void BtnSil_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Ogrenci selectedCategory = DbOgrenci.SelectedItem as Ogrenci;

                Db.Context.Ogrenciler.Remove(selectedCategory);
                Db.Context.SaveChanges();
                MessageBox.Show("Silme İşlemi Başarılı.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme İşlemi Başarısız.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Listele();
        }

        private void BtnGüncelle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Ogrenci selectedCategory = DbOgrenci.SelectedItem as Ogrenci;
                selectedCategory.Ad = TbOgrenciAdı.Text;
                selectedCategory.Soyad = TbOgrenciSoyadı.Text;
                selectedCategory.Numara = TbOgrenciNumarası.Text;
                selectedCategory.Tarih = TbOgrenciTarih.Text;
                selectedCategory.Adres = TbOgrenciAdres.Text;
                Db.Context.SaveChanges();
                MessageBox.Show("Güncelleme İşlemi Başarılı.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme İşlemi Başarısız.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Listele();
            Bosalt();
        }

        private void DbOgrenci_Selected(object sender, RoutedEventArgs e)
        {
            Ogrenci selectedCategorys = DbOgrenci.SelectedItem as Ogrenci;
            TbOgrenciAdı.Text = selectedCategorys.Ad;
            TbOgrenciSoyadı.Text = selectedCategorys.Soyad;
            TbOgrenciNumarası.Text = selectedCategorys.Numara;
            TbOgrenciTarih.Text = selectedCategorys.Tarih;
            TbOgrenciAdres.Text = selectedCategorys.Adres;
        }
    }
}
