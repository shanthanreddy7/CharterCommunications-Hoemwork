using System;
using System.Collections.Specialized;
using System.Windows.Input;
using Android.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace SampleApp.Droid
{
    public class LinkerPleaseInclude
    {
        public void Include(Button button)
        {
            button.Click += (s, e) => button.Text = button.Text + "";
        }

        public void Include(CheckBox checkBox)
        {
            checkBox.CheckedChange += (sender, args) => checkBox.Checked = !checkBox.Checked;
        }

        public void Include(Switch @switch)
        {
            @switch.CheckedChange += (sender, args) => @switch.Checked = !@switch.Checked;
        }

        public void Include(View view)
        {
            view.Click += (s, e) => view.ContentDescription = view.ContentDescription + "";
        }

        public void Include(ImageView imageView)
        {
            imageView.Click += (s, e) => imageView.ContentDescription = imageView.ContentDescription + "";
        }

        public void Include(TextView text)
        {
            text.Click += (s, e) => text.ContentDescription = text.ContentDescription + "";
            text.TextChanged += (sender, args) => text.Text = "" + text.Text;
            text.Hint = "" + text.Hint;
        }

        public void Include(CheckedTextView text)
        {
            text.AfterTextChanged += (sender, args) => text.Text = "" + text.Text;
            text.Hint = "" + text.Hint;
        }

        public void Include(CompoundButton cb)
        {
            cb.CheckedChange += (sender, args) => cb.Checked = !cb.Checked;
        }

        public void Include(SeekBar sb)
        {
            sb.ProgressChanged += (sender, args) => sb.Progress = sb.Progress + 1;
        }

        public void Include(LinearLayout layout)
        {
            layout.Click += (s, e) => layout.ContentDescription = layout.ContentDescription + "";
        }

        public void Include(RadioButton radioButton)
        {
            radioButton.Click += (s, e) => radioButton.Text = radioButton.Text + "";
            radioButton.CheckedChange += (s, e) => radioButton.Checked = !radioButton.Checked;
            radioButton.Text = radioButton.Text + "";
        }

        public void Include(RadioGroup radioGroup)
        {
            radioGroup.CheckedChange += (s, e) => radioGroup.ContentDescription = radioGroup.ContentDescription + "";
        }

        public void Include(RatingBar ratingBar)
        {
            ratingBar.RatingBarChange += (sender, args) => ratingBar.Rating = 0 + ratingBar.Rating;
        }

        public void Include(Activity act)
        {
            act.Title = act.Title + "";
        }

        public void Include(INotifyCollectionChanged changed)
        {
            // ReSharper disable once UnusedVariable
            changed.CollectionChanged += (s, e) => { string test = $"{e.Action}{e.NewItems}{e.NewStartingIndex}{e.OldItems}{e.OldStartingIndex}"; };
        }

        public void Include(ICommand command)
        {
            command.CanExecuteChanged += (s, e) => { if (command.CanExecute(null)) command.Execute(null); };
        }

        // ReSharper disable once RedundantAssignment
        public void Include(MvvmCross.IoC.MvxPropertyInjector injector)
        {
            // ReSharper disable once RedundantAssignment
            injector = new MvvmCross.IoC.MvxPropertyInjector();
        }

        public void Include(System.ComponentModel.INotifyPropertyChanged changed)
        {
            changed.PropertyChanged += (sender, e) =>
            {
                // ReSharper disable once UnusedVariable
                var test = e.PropertyName;
            };
        }

        public void Include(MvxTaskBasedBindingContext context)
        {
            context.Dispose();
            var context2 = new MvxTaskBasedBindingContext();
            context2.Dispose();
        }

        // ReSharper disable once RedundantAssignment
        public void Include(MvxNavigationService service, IMvxViewModelLoader loader)
        {
            // ReSharper disable once RedundantAssignment
            service = new MvxNavigationService(null, loader);
        }

        public void Include(Android.Widget.SearchView searchView)
        {
            searchView.QueryTextChange += (s, e) => { if (searchView.Query == null) searchView.SetQuery(string.Empty, false); };
            searchView.QueryTextSubmit += (s, e) => { if (searchView.QueryHint == null) searchView.SetQueryHint(string.Empty); };
        }

        // ReSharper disable once RedundantAssignment
        public void Include(ConsoleColor color)
        {
            Console.Write("");
            Console.WriteLine("");
            // ReSharper disable once RedundantAssignment
            color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        public void Include(SwitchCompat switchCompat)
        {
            switchCompat.Checked = true;
            switchCompat.Click += (s, e) => switchCompat.Checked = false;
        }

        public void Include(ProgressBar progressBar)
        {
            progressBar.Max = progressBar.Max;
            progressBar.Progress = progressBar.Progress;
        }

        public void Include(RecyclerView.ViewHolder vh, MvxRecyclerView list)
        {
            vh.ItemView.Click += (sender, args) => { };
            vh.ItemView.LongClick += (sender, args) => { };
            list.ItemsSource = null;
            list.Click += (sender, args) => { };
        }
    }
}