using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace observablecollection
{
    class Test
	{
		public void Execute()
		{
			var list = new ObservableCollection<Person>()
			{
				new Person("aaa", 4),
				new Person("bbb", 7),
				new Person("ccc", 5),
				new Person("ccc", 1),
			};

			foreach(var item in list)
			{
				this.newPersons.Add(new NewPerson(item));
			}

			foreach(var item in list)
			{
				Console.WriteLine(item);
			}

			foreach(var item in this.newPersons)
			{
				Console.WriteLine(item);
			}

			list.CollectionChanged += this.L_list_CollectionChanged;
			list.Sort<Person, int>(x => x.Age);

			foreach(var item in list)
			{
				Console.WriteLine(item);
			}

			foreach(var item in this.newPersons)
			{
				Console.WriteLine(item);
			}

			list.Add(new Person("nnn", 3));

			foreach(var item in list)
			{
				Console.WriteLine(item);
			}

			foreach(var item in this.newPersons)
			{
				Console.WriteLine(item);
			}

			list.Move(1, 3);

			foreach(var item in list)
			{
				Console.WriteLine(item);
			}

			foreach(var l_p in this.newPersons)
			{
				Console.WriteLine(l_p);
			}

			var target = list[2];
			list.Remove(target);

			foreach(var item in list)
			{
				Console.WriteLine(item);
			}

			foreach(var l_p in this.newPersons)
			{
				Console.WriteLine(l_p);
			}

			list.Clear();
		}

		private ObservableCollection<NewPerson> newPersons
			= new ObservableCollection<NewPerson>();

		private void L_list_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
				case NotifyCollectionChangedAction.Add:
					Console.WriteLine("Add");
					Console.WriteLine($"new:{e.NewStartingIndex}, old:{e.OldStartingIndex}");
					Console.WriteLine($"new:{e.NewItems[0]}, old:{e.OldItems?[0]}");
					if (e.NewItems[0] is Person p)
					{
						this.newPersons.Insert(e.NewStartingIndex, new NewPerson(p));
					}
					break;

				case NotifyCollectionChangedAction.Move:
					Console.WriteLine("Move");
					Console.WriteLine($"new:{e.NewStartingIndex}, old:{e.OldStartingIndex}");
					Console.WriteLine($"new:{e.NewItems[0]}, old:{e.OldItems[0]}");
					this.newPersons.Move(e.OldStartingIndex, e.NewStartingIndex);
					break;

				case NotifyCollectionChangedAction.Remove:
					Console.WriteLine("Remove");
					Console.WriteLine($"new:{e.NewStartingIndex}, old:{e.OldStartingIndex}");
					Console.WriteLine($"new:{e.NewItems?[0]}, old:{e.OldItems[0]}");
					var olditem = this.newPersons.First(x => x.Acent == e.OldItems[0]);
					if (olditem != null)
					{
						this.newPersons.Remove(olditem);
					}
					break;

				case NotifyCollectionChangedAction.Replace:
					Console.WriteLine("Replace");
					Console.WriteLine($"new:{e.NewStartingIndex}, old:{e.OldStartingIndex}");
					Console.WriteLine($"new:{e.NewItems[0]}, old:{e.OldItems[0]}");
					var newitem = this.newPersons.FirstOrDefault(x => x.Acent == e.NewItems[0]);
					if (newitem != null)
					{
						this.newPersons.Move(this.newPersons.IndexOf(newitem), e.NewStartingIndex);
					}
					break;

				case NotifyCollectionChangedAction.Reset:
					Console.WriteLine("Reset");
					this.newPersons.Clear();
					break;
			}
		}

		private class Person
		{
			public string Name { get; set; }
			public int Age { get; set; }

			public Person(string name, int age)
			{
				this.Name = name;
				this.Age = age;
			}

			public override string ToString()
			{
				return $"{this.Name}:{this.Age}";
			}
		}

		private class NewPerson
		{
			public Person Acent { get; set; }

			public NewPerson(Person acent)
			{
				this.Acent = acent;
			}

			public override string ToString()
			{
				return $"New:{this.Acent.Name}:{this.Acent.Age}";
			}
		}
	}
}
