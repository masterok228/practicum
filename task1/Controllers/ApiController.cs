using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace task1.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        [HttpGet("num/{n}")]
        public ActionResult<string> One(int n)
        {
            return JsonConvert.SerializeObject(RusNumber.Str(n));
        }
        [HttpGet("equation")]
        public ActionResult<string> Two(double a, double b, double c)
        {
            double d = b * b - 4 * a * c;
            if (d < 0) return JsonConvert.SerializeObject("Корней нет");
            if (d == 0)
            {
                double x = -b / (2 * a);
                return JsonConvert.SerializeObject(x);
            }
            else
            {
                double x1 = (-b + Math.Sqrt(d))/ (2 * a);
                double x2 = (-b - Math.Sqrt(d)) / (2 * a);
                return JsonConvert.SerializeObject(new double[] { x1, x2 });
            }
        }
        [HttpGet("date")]
        public ActionResult<string> Three(string date)
        {
            DateTime dateValue;
            string[] dmy = date.Split(new char[] { '.' });
            try
            {
                dateValue = new DateTime(int.Parse(dmy[2]), int.Parse(dmy[1]), int.Parse(dmy[0]));
            }
            catch
            {
                return JsonConvert.SerializeObject("");
            }
            return JsonConvert.SerializeObject(dateValue.ToString("dddd", new CultureInfo("ru-RU")));
        }

        [HttpGet("fib/{n}")]
        public ActionResult<string> Four(int n)
        {//Использована формула Бине
            double answer = Math.Round(Math.Pow((1 + Math.Sqrt(5)) / 2, n) - Math.Pow((1 - Math.Sqrt(5)) / 2, n)) / Math.Sqrt(5);

            return JsonConvert.SerializeObject(answer);
        }

        [HttpGet("region/{n}")]
        public ActionResult<string> Five(int n)
        {
            string[] regions = new string[] {
                "",
                "Республика Адыгея (Адыгея)",
                "Республика Башкортостан",
                "Республика Бурятия",
                "Республика Алтай",
                "Республика Дагестан",
                "Республика Ингушетия",
                "Кабардино-Балкарская Республика",
                "Республика Калмыкия",
                "Карачаево-Черкесская Республика",
                "Республика Карелия",
                "Республика Коми",
                "Республика Марий Эл",
                "Республика Мордовия",
                "Республика Саха (Якутия)",
                "Республика Северная Осетия - Алания",
                "Республика Татарстан (Татарстан)",
                "Республика Тыва",
                "Удмуртская Республика",
                "Республика Хакасия",
                "Чеченская Республика",
                "Чувашская Республика - Чувашия",
                "Алтайский край",
                "Краснодарский край",
                "Красноярский край",
                "Приморский край",
                "Ставропольский край",
                "Хабаровский край",
                "Амурская область",
                "Архангельская область",
                "Астраханская область",
                "Белгородская область",
                "Брянская область",
                "Владимирская область",
                "Волгоградская область",
                "Вологодская область",
                "Воронежская область",
                "Ивановская область",
                "Иркутская область",
                "Калининградская область",
                "Калужская область",
                "Камчатский край",
                "Кемеровская область",
                "Кировская область",
                "Костромская область",
                "Курганская область",
                "Курская область",
                "Ленинградская область",
                "Липецкая область",
                "Магаданская область",
                "Московская область",
                "Мурманская область",
                "Нижегородская область",
                "Новгородская область",
                "Новосибирская область",
                "Омская область",
                "Оренбургская область",
                "Орловская область",
                "Пензенская область",
                "Пермский край",
                "Псковская область",
                "Ростовская область",
                "Рязанская область",
                "Самарская область",
                "Саратовская область",
                "Сахалинская область",
                "Свердловская область",
                "Смоленская область",
                "Тамбовская область",
                "Тверская область",
                "Томская область",
                "Тульская область",
                "Тюменская область",
                "Ульяновская область",
                "Челябинская область",
                "Забайкальский край",
                "Ярославская область",
                "г. Москва",
                "Санкт-Петербург",
                "Еврейская автономная область",
                "Ненецкий автономный округ",
                "Ханты-Мансийский автономный округ - Югра",
                "Чукотский автономный округ",
                "Ямало-Ненецкий автономный округ",
                "Иные территории, включая город и космодром Байконур" };
            string nRegion = regions[n];

            return JsonConvert.SerializeObject(nRegion);
        }
    } 
}