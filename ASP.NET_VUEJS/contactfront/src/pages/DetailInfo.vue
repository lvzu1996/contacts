<template>
    <div id='detaiinfo'>
        <div>name:{{form.name}}</div>
        <div>gender:{{form.gender}}</div>
        <div>company:{{form.company}}</div>
        <div>phone:{{form.phonenumber}}</div>
        <div>createdtime:{{showDate}}</div>
        <input type="button" name="home" value="返回主页" @click="_toHome">

    </div>   
</template>

<script>
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
         form:{
          name:'',
          gender:'',
          company:'',
          phonenumber:'',
          createdtime:''
        },
     }
    },

    methods:{
        _toHome(){
            this.$router.push({
                path: '/'
            })
        },
    },

    created() {
    //do something before mounting vue instance
            this.id = this.$route.query.id;
            fetch(`/App/QuerySingleContact?id=${this.id}`)
            .then(res => res.json())
            .then(res => {
            this.form = res[0]
        })
    },

     computed: {
      showDate(){
          if(this.form.createdtime){
              return eval('new ' + eval(this.form.createdtime).source).Format(DATEFORMATE)
          }
          return ''
      }

  },
}
</script>

<style>

#detaiinfo {
  font-size: 20px;
}

input[type="button"] {
  margin-left: 40px;
  margin-top: 40px;
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

</style>
