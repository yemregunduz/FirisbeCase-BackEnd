using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirisbeCase.Domain.Constants
{
    public class Messages
    {
        public static readonly string AuthorCreated = "Yazar oluşturuldu.";
        public static readonly string AuthorsListed = "Yazarlar listelendi";
        public static readonly string BookCreated = "Kitap oluşturuldu.";
        public static readonly string BooksListed = "Kitaplar listelendi.";
        public static readonly string CategoryCreated = "Kategori oluşturuldu.";
        public static readonly string CategoriesListed = "Kategoriler listelendi";
        public static readonly string BookIsAlreadyExist = "Bu kitap daha önce eklenmiştir.";
        public static readonly string AuthorIsNotFound = "Kitaba eklenecek yazar bulunamadı.";
        public static readonly string CategoryIsNotFound = "Kitabın ekleneceği kategori bulunamadı.";
        public static readonly string CategoryAlreadyExist = "Bu kategori daha önce eklenmiştir.";
        public static readonly string ABookRegisteredToIsbn = "Bu isbn numarasına kayıtlı bir kitap zaten var.";
    }
}
