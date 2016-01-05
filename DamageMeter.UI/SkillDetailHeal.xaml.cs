﻿using System;
using System.Windows;
using System.Windows.Input;
using DamageMeter.Skills.Skill.SkillDetail;
using Data;

namespace DamageMeter.UI
{
    /// <summary>
    ///     Logique d'interaction pour SkillContent.xaml
    /// </summary>
    public partial class SkillDetailHeal
    {
        public SkillDetailHeal(SkillDetailStats skill)
        {
            InitializeComponent();
            Update(skill);
        }

        public void Update(SkillDetailStats skill)
        {
            
            var hit = BasicTeraData.Instance.SkillDatabase.Hit(skill.PlayerInfo.Class, skill.Id);
            var chained = BasicTeraData.Instance.SkillDatabase.IsChained(skill.PlayerInfo.Class, skill.Id);
            if (hit != null)
            {
                LabelName.Content = hit;
            }
            if (chained == true)
            {
                LabelName.Content += " Chained";
            }


            LabelId.Content = skill.Id;
            LabelCritRateHeal.Content = skill.CritRateHeal + "%";


            LabelNumberHitHeal.Content = skill.HitsHeal;
            LabelNumberCritHeal.Content = skill.CritsHeal;

            LabelTotalHeal.Content = FormatHelpers.Instance.FormatValue(skill.Heal);
            LabelBiggestHit.Content = FormatHelpers.Instance.FormatValue(skill.HealBiggestHit);
            LabelBiggestCrit.Content = FormatHelpers.Instance.FormatValue(skill.HealBiggestCrit);


            LabelAverageCrit.Content = FormatHelpers.Instance.FormatValue(skill.HealAverageCrit);
            LabelAverageHit.Content = FormatHelpers.Instance.FormatValue(skill.HealAverageHit);
            LabelAverage.Content = FormatHelpers.Instance.FormatValue(skill.HealAverageTotal);

        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            var w = Window.GetWindow(this);
            try
            {
                w?.DragMove();
            }
            catch
            {
                Console.WriteLine(@"Exception move");
            }
        }
    }
}