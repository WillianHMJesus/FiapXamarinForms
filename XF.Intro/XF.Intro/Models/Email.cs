﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XF.Intro.Models
{
    public class Email : INotifyPropertyChanged
    {
        public bool ativo;
        public bool Ativo
        {
            get { return ativo; }

            set
            {
                ativo = value;
                if (!ativo) contaEmail = string.Empty;
            }
        }

        private string contaEmail;

        public string ContaEmail
        {
            get
            {
                return contaEmail;
            }
            set
            {
                contaEmail = value;
                EventPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
