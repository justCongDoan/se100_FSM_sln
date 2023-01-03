using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.ComponentModel;

namespace FlowerShopManagementSystem.Resources
{
    internal class PagingCollectionView : CollectionView
    {
        private readonly IList _innerList;
        private readonly int _itemsPerPage;

        private int _currentPage = 1;

        public PagingCollectionView(IList innerList, int itemsPerPage) : base(innerList)
        {
            _innerList = innerList;
            _itemsPerPage = itemsPerPage;
        }

        public int CurrentPage
        {
            get { return _currentPage; }

            set
            {
                _currentPage = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentPage"));
            }
        }

        public int ItemsPerPage { get { return _itemsPerPage; } }

        public int PageCount
        {
            get
            {
                return (_innerList.Count + _itemsPerPage - 1) / _itemsPerPage;
            }
        }

        private int StartIndex
        {
            get { return (this._currentPage - 1) * this._itemsPerPage; }
        }

        public override object GetItemAt(int index)
        {
            var offset = index % (this._itemsPerPage);
            return this._innerList[this.StartIndex + offset];
        }

        public override int Count
        {
            get
            {
                if (this._innerList.Count == 0) return 0;
                if (this._currentPage < this.PageCount) // page 1..n-1
                {
                    return this._itemsPerPage;
                }
                else // page n
                {
                    var itemsLeft = this._innerList.Count % this._itemsPerPage;
                    if (0 == itemsLeft)
                    {
                        return this._itemsPerPage; // exactly itemsPerPage left
                    }
                    else
                    {
                        // return the remaining items
                        return itemsLeft;
                    }
                }
            }
        }

        public void MoveToFirstPage()
        {
            if (this._currentPage > 1)
            {
                this.CurrentPage = 1;
            }
            this.Refresh();
        }

        public void MoveToNextPage()
        {
            if (this._currentPage < this.PageCount)
            {
                this.CurrentPage += 1;
            }
            this.Refresh();
        }

        public void MoveToPreviousPage()
        {
            if (this._currentPage > 1)
            {
                this.CurrentPage -= 1;
            }
            this.Refresh();
        }

        public void MoveToLastPage()
        {
            if (this._currentPage < this.PageCount)
            {
                this.CurrentPage = PageCount;
            }
            this.Refresh();
        }
    }
}
