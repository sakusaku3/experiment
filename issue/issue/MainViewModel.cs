using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace issue
{
    public class MainViewModel : ViewModelBase
    {
        public string Condition
        {
            get { return this._condition; }
            set { if (this._condition != value) { this._condition = value; this.OnPropertyChanged(); } }
        }
        private string _condition = "";

        public ObservableCollection<Issue> Issues { get; set; }
        = new ObservableCollection<Issue>();

        public DelegateCommand FilterCommand
        {
            get
            {
                return this._filterCommand = this._filterCommand ??
                        new DelegateCommand(
                            () => this.filterExecute(this.Condition),
                            () => !string.IsNullOrWhiteSpace(this.Condition)
                            );
            }
        }
        private DelegateCommand _filterCommand;

        public DelegateCommand ClearCommand
        {
            get
            {
                return this._clearCommand = this._clearCommand ??
                        new DelegateCommand(
                            () => this.clearExecute(),
                            () => true
                            );
            }
        }
        private DelegateCommand _clearCommand;

        private List<Issue> allIssues
            = new List<Issue>();

        public MainViewModel()
        {
            this.allIssues = new List<Issue>()
            {
                new Issue("AAA"){ Labels = new ObservableCollection<Label>(){ new Label("aaa", this.filterExecute), new Label("aa", this.filterExecute) } },
                new Issue("BBB"){ Labels = new ObservableCollection<Label>(){ new Label("bbbb", this.filterExecute), new Label("bbb", this.filterExecute) } }
            };

            foreach (var l_i in this.allIssues)
            {
                this.Issues.Add(l_i);
            }
        }

        private void filterExecute(string p_filter)
        {
            this.Issues.Clear();

            var l_matches = this.allIssues.Where(x => x.Labels.Any(y => y.Name == p_filter));

            foreach (var l_i in l_matches)
            {
                this.Issues.Add(l_i);
            }
        }

        private void clearExecute()
        {
            this.Issues.Clear();

            foreach (var l_i in this.allIssues)
            {
                this.Issues.Add(l_i);
            }
        }
    }
}
