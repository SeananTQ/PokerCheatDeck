using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeananTools;
namespace ExcelTools
{
    internal class NftActorData
    {
        public string? actorName = null;//角色名
        public string? part = null;//部位
        public string? linkPart = null;//关联部位
        public string? linkCallName = null;//关联部位称呼名
        public string? callName = null;//称呼名
        //public string? nickName = null;//昵称
        public string? abcLayer = null;//层级
        public string? colorId = null;//颜色号
        public string? suffix = null;//后缀
        public string? effect = null;//特效

        private static string[] actorNameSamples = { "wwx", "lwj" };
        private static string[] partSamples = { "body", "skin", "eye", "face", "FO", "mouth", "ear", "hair", "head", "headwear", "cloth", "tatoo", "neck", "hand", "handwear", "shoulder", "bg" };
        private static string[] abcSamples = { "A", "B", "C" };
        private static string[] effectSamples = { "shadow", "light", "flur", "abstract" };
        private static string[] selfDestroySamples = { "背景" };//在自毁列表中的图层不会被合并到表中


        private static string[] characterTypeSamples = { "" };//110
        private static string[] bodyTypeSamples = { "body" };//120
        private static string[] skinTypeSamples = { "skin" };//130
        private static string[] eyeTypeSamples = { "eye" };//140
        private static string[] mouthTypeSamples = { "mouth" };//150
        private static string[] faceTypeSamples = { "FO", "face" };//160
        private static string[] earTypeSamples = { "ear" };//170
        private static string[] hairTypeSamples = { "hair" };//180
        private static string[] headTypeSamples = { "headwear", "head" };//190
        private static string[] clothTypeSamples = { "cloth" };//200
        private static string[] maskTypeSamples = { "tatoo", "mask" };//210
        private static string[] neckTypeSamples = { "neck" };//220
        private static string[] handTypeSamples = { "hand", "object" };//230
        private static string[] ringTypeSamples = { "handwear", "ring" };//240
        private static string[] specialTypeSamples = { "shoulder", "special" };//250
        private static string[] backgroundTypeSamples = { "bg", "background" };//260



        public bool isNude = false;//是否为裸部位
        private string[]? layerData;
        public string layerName;//原始数据存根
        public bool isCombined = false;//是否为合并过的
        public string type = "";//类型
        public string name = "";//名字序号
        public int orderValue = 0;//排序值
        public int probability = 0;//权重
        public int segmentCount//段数
        {
            get
            {
                return layerData.Length;
            }
        }




        //计算部位属于哪种类型，以及排序值
        public string CalculatePartTypeAndOrderValue()
        {
            if (part == null)
            {
                orderValue = 9999;
                return "";
            }
            if (bodyTypeSamples.Contains(part))
            {
                orderValue = 120;
                return "body";
            }
            if (skinTypeSamples.Contains(part))
            {
                orderValue = 130;
                return "skin";
            }
            if (eyeTypeSamples.Contains(part))
            {
                orderValue = 140;
                return "eye";
            }
            if (mouthTypeSamples.Contains(part))
            {
                orderValue = 150;
                return "mouth";
            }
            if (faceTypeSamples.Contains(part))
            {
                orderValue = 160;
                return "face";
            }
            if (earTypeSamples.Contains(part))
            {
                orderValue = 170;
                return "ear";
            }
            if (hairTypeSamples.Contains(part))
            {
                orderValue = 180;
                return "hair";
            }
            if (headTypeSamples.Contains(part))
            {
                orderValue = 190;
                return "head";
            }
            if (clothTypeSamples.Contains(part))
            {
                orderValue = 200;
                return "cloth";
            }
            if (maskTypeSamples.Contains(part))
            {
                orderValue = 210;
                return "mask";
            }
            if (neckTypeSamples.Contains(part))
            {
                orderValue = 220;
                return "neck";
            }
            if (handTypeSamples.Contains(part))
            {
                orderValue = 230;
                return "hand";
            }
            if (ringTypeSamples.Contains(part))
            {
                orderValue = 240;
                return "ring";
            }
            if (specialTypeSamples.Contains(part))
            {
                orderValue = 250;
                return "special";
            }
            if (backgroundTypeSamples.Contains(part))
            {
                orderValue = 260;
                return "background";
            }
            return "";
        }

        //比较两个对象的orderValue，将小的返回，如果相等，再比较layerName，如果是Nude则自动排到最前面
        public static int CompareOrderValue(NftActorData a, NftActorData b)
        {

            if (a.orderValue < b.orderValue)
                return -1;
            if (a.orderValue > b.orderValue)
                return 1;
            if (a.callName != null && a.callName.Equals("nude") && (b.callName != null && b.callName.Equals("nude") == false))
                return -1;
            if (b.callName != null && b.callName.Equals("nude") && (a.callName != null && a.callName.Equals("nude") == false))
                return 1;
            if (a.layerName.CompareTo(b.layerName) < 0)
                return -1;
            if (a.layerName.CompareTo(b.layerName) > 0)
                return 1;
            return 0;
        }


        public static int CompareOrderValueAndName(NftActorData a, NftActorData b)
        {
            if (a.orderValue < b.orderValue)
                return -1;
            if (a.orderValue > b.orderValue)
                return 1;
            if (a.name.CompareTo(b.name) < 0)
                return -1;
            if (a.name.CompareTo(b.name) > 0)
                return 1;
            return 0;
        }

        
        //比较两个对象是否相似
        public bool CompareAll(NftActorData other)
        {
            //检查是否为裸部位，如果为裸部位则不相似
            if (this.isNude || other.isNude)
                return false;
            //如果是备胎，则不相似
            if (this.suffix != null && this.suffix.Equals("spare") || other.suffix != null && other.suffix.Equals("spare"))
                return false;
            //如果是自己，则直接返回true
            if (this == other)
                return true;
            //检查角色名
            if  (this.actorName==null ||other.actorName==null ||       (actorName != other.actorName))
            {
                return false;
            }
            //自己不能是特效，特效无权检查其他对象
            if (this.effect != null)
            {
                return false;
            }
            //检查部位
            if (ComparePart(other) == false)
            {
                return false;
            }

            //检查称呼名
            if (CompareCallName(other) == false)
            {
                return false;
            }

            //如果颜色id不为空，但不相同，则不相似
            if (colorId != null && other.colorId !=null && colorId != other.colorId)
            {
                return false;
            }
            //如果后缀不为空，但是后缀不相同，则不相似
            if (suffix != null && other.suffix!=null &&  suffix != other.suffix )
            {
                return false;
            }
            ////检查自己或对方是否有一个是特效，如果是则按照特效处理流程
            //if (other.effect != null)
            //{
            //    if (!this.CompareEffect(other) && !other.CompareEffect(this))
            //    {
            //        return false;
            //    }
            //}
            return true;
        }

        //比较两个对象的CallName
        private bool CompareCallName(NftActorData other)
        {
            //如果两个都没有关联部位，且称呼不同，则认为不相似
            if ((this.linkPart == null && other.linkPart == null) && (callName != null && other.callName != null && callName != other.callName))
            {
                return false;
            }
            //如果两个都有关联部位，且称呼不同，则认为不相似
            if ((this.linkPart != null && other.linkPart != null) && (callName != null && other.callName != null && callName != other.callName))
            {
                return false;
            }

            return true;
        }

        //比较特效对象与另一个对象是否相似
        private bool CompareEffect(NftActorData other)
        {
            //如果自己不是特效，则返回false
            if (this.effect == null)
            {
                return false;
            }
            //将两个对象共有的字段进行比较，如果出现不相同的字段则认为不相似
            //比较颜色
            if (this.colorId != null && other.colorId != null && this.colorId != other.colorId)
            {
                return false;
            }
            //比较后缀
            else if (this.suffix != null && other.suffix != null && this.suffix != other.colorId)
            {
                return false;
            }            


         return true;
        }
        


        //比较两个对象是否为相似部位
        private bool ComparePart(NftActorData other)
        {
            //如果双方都是关联部位，那么检查双方关联的是不是同一个部位
            if (this.linkPart != null && other.linkPart != null )
            {
                if (this.linkPart.Equals(other.linkPart) == false || this.linkCallName.Equals(other.linkCallName) == false)
                {
                    return false;
                }
            }
            //如果一方有关联部位，那么就与另一方的部位进行比较，判断是否相似
            else
            {
                if ((this.linkPart != null && this.linkPart.Equals(other.part) == false) || (other.linkPart != null && other.linkPart.Equals(this.part) == false))
                {
                    return false;
                }
                if ((this.linkCallName != null && this.linkCallName.Equals(other.callName) == false) || (other.linkCallName != null && other.linkCallName.Equals(this.callName) == false))
                {
                    return false;
                }
            }

            //部位相似情况下，但如果所属部位(type)不相同，则不相似
            if (this.type.Equals(other.type) == false)
            {
                return false;
            }
            //最后
            return true;
        }



        //比较两个对象是否相似
        public bool compareAll(NftActorData other)
        {          
            //检查是否为裸部位，如果为裸部位则跟任何都不同
            if (this.isNude || other.isNude)
                return false;
            //如果是备胎，则跟任何都不同
            if (this.suffix!=null &&  this.suffix.Equals("spare") || other.suffix!=null &&  other.Equals("spare"))
                return false;
            //如果是自己，则直接返回true
            if (this == other)
                return true;
            //检查角色名
            if (actorName != other.actorName)
            {
                return false;
            }

            //检查自己或对方是否有一个是特效，如果是则按照特效处理流程
            if (effect != null | other.effect != null)
            {
                //将两个对象共有的字段进行比较，如果出现不相同的字段则认为不相似
                //首先比较type，如果不同，则认为不相似
                if (this.type.Equals(other.type) == false)
                {
                    return false;
                }
                else if (this.colorId != null && other.colorId != null && this.colorId != other.colorId)
                {
                    return false;
                }
                else if (this.suffix != null && other.suffix != null && this.suffix != other.colorId)
                {
                    return false;
                }

                var tempArray = other.layerData.ToList();
                var thisArray = this.layerData.ToList();
                tempArray.Remove(other.effect);
                for (int i = 0; i < tempArray.Count; i++)
                {
                    if (this.layerData.Contains(tempArray[i]) == false)
                    {
                        return false;
                    }
                }       
            }
            //如果不是特效才检查其他项
            else
            {
                //如果有关联部位，就检查关联部位的名称，如果没有才检查其他的
                if (linkPart != null)
                {
                    //如果关联部位与被关联的部位不同，则不相似
                    if (this.linkPart.Equals(other.part) == false)
                    {

                        return false;
                    }
                    else
                    {
                        //部位相同情况下，如果所属部位(type)不相同，则不相似
                        if (this.type.Equals(other.type) == false)
                        {
                            return false;
                        }
                        //如果部位相同，但称呼名不同，则不相似
                        if (linkCallName.Equals(other.callName) == false)
                        {
                            return false;
                        }
                    }
                }
                //如果没有关联部位，才检查其他项
                else
                {
                    //然后检查部位
                    if (part != other.part)
                    {
                        return false;
                    }
                    //检查称呼名，如果称呼名不同，则不相似
                    if (callName != other.callName)
                    {
                        return false;
                    }
                    //如果颜色id不为空，但不相同，则不相似
                    if (colorId != null & colorId != other.colorId)
                    {
                        return false;
                    }
                    //如果后缀不为空，但是后缀不相同，则不相似
                    if (suffix != null & suffix != other.suffix & other.suffix != null)
                    {
                        return false;
                    }
                }
            }



            return true;
        }


        //构造方法
        public NftActorData(string layerName, bool isCombined, string? part)
        {
            this.part = part;
            this.type = CalculatePartTypeAndOrderValue();
            this.layerName = layerName;
            this.isCombined = isCombined;
        }


        public NftActorData(string layerName)
        {
            if (layerName == null) return;
            this.layerName = layerName;
            this.layerData = layerName.Split('_');
            List<string> curStringList = layerData.ToList();
            if (segmentCount == 1)
            {
                part = layerData[0];
                this.type = CalculatePartTypeAndOrderValue();
            }
            else if (segmentCount == 2)
            {
                if (actorNameSamples.Contains(layerData[0]))
                {
                    actorName = layerData[0];
                    part = layerData[1];
                    this.type = CalculatePartTypeAndOrderValue();
                }
                else
                {
                    part = layerData[0];
                    this.type = CalculatePartTypeAndOrderValue();
                    callName = layerData[1];
                }
            }
            else if (segmentCount >= 3)
            {
                //角色
                actorName = curStringList[0];
                curStringList.Remove(actorName);
                //部位
                part = curStringList[0];
                this.type = CalculatePartTypeAndOrderValue();
                curStringList.Remove(part);
                if (curStringList.Count == 0) return;
                //循环对比是否含有关联部位
                for (int i = 0; i < curStringList.Count; i++)
                {
                    //如果含有关联部位，则记录关联部位以及关联部位id
                    if (partSamples.Contains(curStringList[i]))
                    {
                        linkPart = curStringList[i];
                        linkCallName = curStringList[i + 1];
                        curStringList.RemoveAt(i + 1);
                        curStringList.Remove(linkPart);
                        break;
                    }
                }
                if (curStringList.Count == 0) return;

                //循环对比是否含有层级
                for (int i = 0; i < curStringList.Count; i++)
                {
                    if (abcSamples.Contains(curStringList[i]))
                    {
                        abcLayer = curStringList[i];
                        curStringList.RemoveAt(i);
                        break;
                    }
                }
                if (curStringList.Count == 0) return;
                //循环对比是否含有特效
                for (int i = 0; i < curStringList.Count; i++)
                {
                    if (effectSamples.Contains(curStringList[i]))
                    {
                        effect = curStringList[i];
                        curStringList.RemoveAt(i);
                        break;
                    }
                }
                if (curStringList.Count == 0) return;
                //如果称呼名空缺，则把当前第一个字符串当做称呼名
                if (callName == null)
                {
                    callName = curStringList[0];
                    curStringList.RemoveAt(0);
                }
                if (curStringList.Count == 0) return;
                //循环对比是否有颜色id
                for (int i = 0; i < curStringList.Count; i++)
                {
                    if (curStringList[i].IsMostLetter() == false)
                    {
                        colorId = curStringList[i];
                        curStringList.RemoveAt(i);
                        break;
                    }
                }
                if (curStringList.Count == 0) return;
                //循环对比是否有后缀
                for (int i = 0; i < curStringList.Count; i++)
                {
                    //如果是字母并且不是特效，则判定他为后缀
                    if (curStringList[i].IsMostLetter() && effectSamples.Contains(curStringList[i]) == false)
                    {
                        suffix = curStringList[i];
                        curStringList.RemoveAt(i);
                        break;
                    }
                }
                if (curStringList.Count == 0) return;
                if (curStringList.Count > 0)
                {
                    DebugClass.Logln("未知字符串：" + layerName);
                }
            }
        }



        public static NftActorData GetNudeObject(string actorName,string type,  int probability)
        {
            var nudeObject = new NftActorData("");
            nudeObject.isNude = true;
            nudeObject.actorName = actorName;
            nudeObject.type = type;
            nudeObject.probability = probability;
            nudeObject.layerData = new string[] { actorName, type };
            nudeObject.part = type;
            nudeObject.CalculatePartTypeAndOrderValue();

            return nudeObject;
        }

    }
}
