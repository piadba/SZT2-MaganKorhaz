﻿#pragma checksum "..\..\IgenyMainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "28E72E1A2833C432AB984233A3E17091"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EFTeszt01;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace EFTeszt01 {
    
    
    /// <summary>
    /// IgenyMainWindow
    /// </summary>
    public partial class IgenyMainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\IgenyMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listBoxEszkozGroupIgeny;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\IgenyMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\IgenyMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button newEszkozGroup;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\IgenyMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listBoxEszkozIgeny;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\IgenyMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\IgenyMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button newEszkoz;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\IgenyMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button groupDelete;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\IgenyMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button eszkozDelete;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\IgenyMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GroupMod;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\IgenyMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button igenyEszkozmod;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/EFTeszt01;component/igenymainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\IgenyMainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.listBoxEszkozGroupIgeny = ((System.Windows.Controls.ListBox)(target));
            
            #line 13 "..\..\IgenyMainWindow.xaml"
            this.listBoxEszkozGroupIgeny.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listBoxEszkozGroupIgeny_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.newEszkozGroup = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\IgenyMainWindow.xaml"
            this.newEszkozGroup.Click += new System.Windows.RoutedEventHandler(this.newEszkozGroup_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.listBoxEszkozIgeny = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.newEszkoz = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\IgenyMainWindow.xaml"
            this.newEszkoz.Click += new System.Windows.RoutedEventHandler(this.newEszkoz_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.groupDelete = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\IgenyMainWindow.xaml"
            this.groupDelete.Click += new System.Windows.RoutedEventHandler(this.groupDelete_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.eszkozDelete = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\IgenyMainWindow.xaml"
            this.eszkozDelete.Click += new System.Windows.RoutedEventHandler(this.eszkozDelete_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.GroupMod = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\IgenyMainWindow.xaml"
            this.GroupMod.Click += new System.Windows.RoutedEventHandler(this.GroupMod_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.igenyEszkozmod = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\IgenyMainWindow.xaml"
            this.igenyEszkozmod.Click += new System.Windows.RoutedEventHandler(this.igenyEszkozmod_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

