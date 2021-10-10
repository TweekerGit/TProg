using System;
using System.Collections.Generic;
using ElementarySchool.Entities;

namespace ElementarySchool
{
	public class ChildrenFactory
	{
		private int _iter = 10;
		private readonly Random _rand = new();


		public IEnumerable<Child> RandomMany(int count, double proportion = 0.5)
		{
			if (count <= 0)
				throw new ArgumentOutOfRangeException(nameof(count));

			for (int i = 0; i < count; i++)
				yield return Random(proportion);
		}

		public Child Random(double proportion = 0.5) => _rand.NextDouble() > proportion ? RandomMale() : RandomFemale();

		public Child RandomMale()
		{
			return new Child
			{
				Id = _iter++,
				Sex = true,
				Age = this.GenerateAge(),
				Name = this.GenerateMaleName()
			};
		}

		public Child RandomFemale()
		{
			return new Child
			{
				Id = _iter++,
				Sex = false,
				Age = this.GenerateAge(),
				Name = this.GenerateFemaleName()
			};
		}


		private static readonly string[] MaleNames = {"Іваня", "Кирюша", "Серьожа", "Нікітка", "Данило", "Денчік", "Стьопа", "Юрій", "Владік", "Костя", "Лесь", "Джон", "Діо", "Димитро", "Ромчик", "Йосип", "Ерен"};
		private static readonly string[] FemaleNames = {"Анічка", "Олена", "Люда", "Оля", "Маруся", "Діана", "Маргарита", "Юля", "Вікторія", "Саша", "Хрестина", "Улянка", "Злата", "Ичіго", "Таня", "Мікаса"};
		private static readonly string[] Surnames = {"Шевченко", "Черненко", "Шмідт", "Ульм", "Гуро Гуро", "Джон", "Попенко", "Романов", "Білочка", "Енштейн", "Ферштейн", "Геббельс", "Габсбург", "Червондель", "Купрій", "Мамамото", "Ніт", "Жмайло", "Тиран", "Загреб", "Мілано", "Драгон", "Нгуен", "Кок", "Орочі", "Євнух", "Більбо", "Ґудзик", "Акерман", "Єгер", "Фіт", "Колбасенко", "Япончик"};

		private string GenerateMaleName() => PickRandom(MaleNames) + " " + PickRandom(Surnames);
		private string GenerateFemaleName() => PickRandom(FemaleNames) + " " + PickRandom(Surnames);
		private byte GenerateAge() => (byte) _rand.Next(5, 16);

		private T PickRandom<T>(IReadOnlyList<T> array) => array[_rand.Next(0, array.Count)];
	}
}