﻿using NUnit.Framework;
using System.ComponentModel;

namespace DarkHelpers.Tests
{
    public class DarkViewModelTests
    {
		[Test]
		public void CanLoadMore()
		{
			PropertyChangedEventArgs updated = null;
			var vm = new DarkViewModel();

			vm.PropertyChanged += (sender, args) =>
			{
				updated = args;
			};

			vm.CanLoadMore = false;
			Assert.IsNotNull(updated, "Property changed didn't raise");
			Assert.AreEqual(updated.PropertyName, nameof(vm.CanLoadMore), "Correct Property name didn't get raised");
		}

		[Test]
		public void IsLoadingMore()
		{
			PropertyChangedEventArgs updated = null;
			var vm = new DarkViewModel();

			vm.PropertyChanged += (sender, args) =>
			{
				updated = args;
			};

			vm.IsLoadingMore = false;
			Assert.IsNotNull(updated, "Property changed didn't raise");
			Assert.AreEqual(updated.PropertyName, nameof(vm.IsLoadingMore), "Correct Property name didn't get raised");
		}

		[Test]
		public void IsBusy()
		{
			PropertyChangedEventArgs updated = null;
			var vm = new DarkViewModel();

			vm.PropertyChanged += (sender, args) =>
			{
				if (args.PropertyName == "IsBusy")
                {
                    updated = args;
                }
            };

			vm.IsBusy = true;
			Assert.IsNotNull(updated, "Property changed didn't raise");
			Assert.AreEqual(updated.PropertyName, nameof(vm.IsBusy), "Correct Property name didn't get raised");

			Assert.IsFalse(vm.IsNotBusy, "Is Not Busy didn't change.");
		}

		[Test]
		public void IsNotBusy()
		{
			PropertyChangedEventArgs updated = null;
			var vm = new DarkViewModel();

			vm.PropertyChanged += (sender, args) =>
			{
				if (args.PropertyName == "IsNotBusy")
                {
                    updated = args;
                }
            };

			vm.IsNotBusy = false;
			Assert.IsNotNull(updated, "Property changed didn't raise");
			Assert.AreEqual(updated.PropertyName, nameof(vm.IsNotBusy), "Correct Property name didn't get raised");

			Assert.IsTrue(vm.IsBusy, "Is Busy didn't change.");
		}
	}
}
