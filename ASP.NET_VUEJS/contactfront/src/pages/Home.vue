<template lang="html">
<div>
  <div class="query-top">
    <h1 @click="_refresh" id="contact">联系人列表</h1>
    <svg class="icon" aria-hidden="true" @click="_getMan">
      <use xlink:href="#icon-nan"></use>
    </svg>
    <svg class="icon" aria-hidden="true" @click="_getWoman">
      <use xlink:href="#icon-nv"></use>
    </svg>
    <el-input v-model="searchStr" placeholder="请输入内容" @change='_search' style='width:200px;'></el-input>
    <input type="button" name="addbtn" value="新增联系人" @click="_toAdd">
    <input type="button" name="sortbytime" value="按时间排序" @click="_sortByTime">
  </div>
  <div class="query-contactList">
  
      <div class="query-contact" v-for="item,index in contactList" :key="item.key">
        <div class="query-infos">
          <img src="http://lvzu-imgs.oss-cn-hangzhou.aliyuncs.com/%E4%B8%8B%E8%BD%BD.png" alt="none" @click='_getDetailInfo(item.id)' class='avatar'>
          <span>{{item.name}}</span>
          <span>{{item.gender}}</span>
          <span>{{item.company}}</span>
          <span>{{item.phonenumber}}</span>
          <span>{{showDate[index]}}</span>
        </div>
        <div class="query-btns">
          <input type="button" name="removeBtn" @click="_toRemove(item.id)" value="删除">
          <input type="button" name="reviseBtn" @click="_toRevice(item.id)" value="修改">
        </div>
      </div>

  </div>
</div>
</template>

<script>
import 'moment'

const DATEFORMATE = "yyyy-MM-dd";
Date.prototype.Format = function (fmt) { //author: meizz 
    var o = {
        "M+": this.getMonth() + 1, //月份 
        "d+": this.getDate(), //日 
        "h+": this.getHours(), //小时 
        "m+": this.getMinutes(), //分 
        "s+": this.getSeconds(), //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds() //毫秒 
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
    if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}

export default {
  data(){
    return {
      host:'http://localhost:52177/App',
      contactList:[],
      dateList:[],
      originDateList:[],
      searchStr:'',
    }
  },
  
  mounted() {
    var _this = this
      fetch(`/App/QueryContact`)
      .then(re => re.json())
      .then(re =>{
        _this.contactList = re
        for(var i of re){
          _this.dateList.push(eval('new ' + eval(i.createdtime).source))
          _this.originDateList.push(eval('new ' + eval(i.createdtime).source))
        }
      })
  },

  methods: {
    _toAdd:function(){
      this.$router.push({
        path: '/add'
      })
    },
    _toRevice(id){
      // fetch()
      this.$router.push({
        path: `/revice?id=${id}`
      })
    },
    _toRemove(id){
      fetch(`/App/RemoveContact?id=${id}`)
        .then(re => re.json())
        .then(re => {
          if(re.msg == "success"){
            this.$router.push({
              path: '/success?type=remove'
            })
          }else {
            this.$router.push({
              path: '/fail?type=remove'
            })
          }
        })
    },
    _sortByTime(){
      var _this = this
      fetch(`/App/QueryContactByDate`)
        .then(re => re.json())
        .then(re =>{
          _this.contactList = re
          _this.dateList = []
          _this.originDateList = []
          for(var i of re){
            _this.dateList.push(eval('new ' + eval(i.createdtime).source))
            _this.originDateList.push(eval('new ' + eval(i.createdtime).source))
          }
        })
      // if(this.dateList.toString() != this.originDateList.toString()){
      //   this.dateList = this.originDateList
      //   return 
      // }
      // var temp = this.dateList.sort((a, b) => b.getTime() - a.getTime())
      // this.dateList = temp;
    },
    _refresh(){
      location.reload()
    },
    _getMan(){
      var _this = this
      fetch(`/App/QueryMaleContact`)
        .then(re => re.json())
        .then(re =>{
          _this.contactList = re
          _this.dateList = []
          _this.originDateList = []
          for(var i of re){
            _this.dateList.push(eval('new ' + eval(i.createdtime).source))
            _this.originDateList.push(eval('new ' + eval(i.createdtime).source))
          }
        })
    },
    _getWoman(){
      var _this = this
      fetch(`/App/QueryFemaleContact`)
        .then(re => re.json())
        .then(re =>{
          _this.contactList = re
          _this.dateList = []
          _this.originDateList = []
          for(var i of re){
            _this.dateList.push(eval('new ' + eval(i.createdtime).source))
            _this.originDateList.push(eval('new ' + eval(i.createdtime).source))
          }
        })
    },
    _search(){
      var _this = this
      fetch(`/App/SearchContact?key=${_this.searchStr}`)
        .then(re => re.json())
        .then(re =>{
          _this.contactList = re
          _this.dateList = []
          _this.originDateList = []
          for(var i of re){
            _this.dateList.push(eval('new ' + eval(i.createdtime).source))
            _this.originDateList.push(eval('new ' + eval(i.createdtime).source))
          }
        })
    },
    _getDetailInfo(id){
      this.$router.push({
        path: `/detailinfo?id=${id}`
      })
    },

  },

  computed: {
      showDate(){
        
        //对paihang这个数组的操作
        var showList = this.dateList.map( date => date.Format(DATEFORMATE))
        return showList
      }

  },

}
</script>

<style lang="css">
#contact:hover{
  cursor: pointer;
}
.icon:hover{
  cursor: pointer;
}
.query-top{
  margin-top: 30px;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-between;
}


.query-top input[type="button"]{
  margin-left: 40px;
  width: 200px;
 height: 50px;
 font-size: 18px;
 font-family: monaco;
 color: #FFF;
 text-decoration: none;
 outline: none;
 letter-spacing: 8px;
 padding-left: 12px;
 border-radius: 5px;
  background-color: #76e097;
}

.query-contactList{
  display: flex;
  flex-direction: column;
  font-size: 20px;
}

.query-contact{
  margin-top: 25px;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
}
.query-contact + .query-contact {
  margin-top: 10px;
}

.query-infos > img {
  width: 50px;
  height: 50px;
  border-radius: 50%;
}

.query-infos > span{
  margin-left: 20px;
  display: flex;
  justify-content: center;
  align-items: center;
  width: 150px;
}

.query-infos{
  display: flex;
  justify-content: center;
}

.query-btn{
  display: flex;
  flex-direction: row;
  justify-content: flex-end;
}
.query-btns > input[type="button"] {
float:right;
  width: 100px;
 height: 50px;
 font-size: 18px;
 font-family: monaco;
 color: #FFF;
 text-decoration: none;
 outline: none;
 letter-spacing: 8px;
 padding-left: 12px;
 border-radius: 5px;
}
.query-btns > input[name="removeBtn"]{
  background-color: #FF7680;
   border-color: #FF7680;
}
.query-btns > input[name="reviseBtn"]{
  margin-left: 50px;
  background-color: #77ceff;
   border-color: #77ceff;
}
.query-btns > input[type="button"] :hover{
  background-color: #FF7680;
}

.avatar:hover{
  cursor: pointer;
}

</style>
