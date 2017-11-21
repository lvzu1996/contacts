<template>
  <div >
    
    <div class="add-top">
      <h1>修改联系人信息</h1>
    </div>
    <form action="App/ReviceContact" method="post" name="contact" id="contact-form">
      <div>name:</div><input v-model="form.name" @blur="_validate(form.name,'name')" type="text" name="name" ><br>
      <div>gender:</div><input v-model="form.gender" type="text" name="gender" ><br>
      <div>company:</div><input v-model="form.company" type="text" name="company"><br>
      <div>phone:</div><input v-model="form.phonenumber" @blur="_validate(form.phonenumber,'phone')" maxlength="11" type="text" name="phonenumber" ><br>
      <input type="button" value="提交" @click="_toRevice">
      <input type="button" name="backbtn" value="返回" @click="_toQuery">
    </form>
  </div>
  
</template>
<script>
import lvValidate from '../utils/lvValidate'

export default {
  data(){
    return {
      host:'http://localhost:52177/App',
      form:{
          name:'',
          gender:'',
          company:'',
          phonenumber:'',
        },
    }
  },
  
  methods: {
    _toQuery() {
      this.$router.push({
        path: '/'
      })
    },
    _toRevice(){
      const t = this
      if(!lvValidate.inputValidate(t.form.name,'name')){
        t.$message.error('姓名不能为空！');
        return
      }
      if(!lvValidate.inputValidate(t.form.phonenumber,'phone')){
        t.$message.error('手机号输入有误！');
        return
      }
      fetch(`http://localhost:52177/App/ReviceContact`,{
        method:'post',
        body: `id=${t.form.id}&name=${t.form.name}&gender=${t.form.gender}&company=${t.form.company}&phonenumber=${t.form.phonenumber}`,
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/x-www-form-urlencoded"
        },
      })
      .then(res => res.json())
      .then(res => {
        if(res.msg == "success"){
          this.$router.push({
            path: '/success?type=revice'
          })
        }
        else if(res.msg == 'used phonenumber'){
          this.$router.push({
            path: '/fail?type=usedpn'
          })
        }
        else {
          this.$router.push({
            path: '/fail?type=revice'
          })
        }
      })
    },
    
    _validate(value,type){
      if(!lvValidate.inputValidate(value,type)){
        var errorMap =  {'name':'姓名请勿为空',
                         'phone':'请输入正确的手机号',}
        var errorMsg = errorMap[type];
        this.$message.error(errorMsg);
      }
    },
    
  },
  
  created() {
    //do something before mounting vue instance
    this.id = this.$route.query.id;
    fetch(`${this.host}/QuerySingleContact?id=${this.id}`)
    .then(res => res.json())
    .then(res => {
      this.form = res[0]
    })
  },
}
</script>
<style lang="css" scoped>

.add-top{
  margin-top: 30px;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
}


#contact-form{
  margin-top: 20px;
  font-size: 20px;
  font-family:Microsoft YaHei;
}

#contact-form > div{
  display: inline-block;
  width: 100px;
  height: 50px;
  text-align: right;
}

#contact-form input[type="text"]{
  margin-left: 20px;
  text-indent:10px;
  display: inline-block;
  width: 400px;
  height: 50px;
}

#contact-form input[type="submit"]{
  margin-left: 70px;
  width: 250px;
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
#contact-form input[type="button"]{
  margin-top: 30px;
  margin-left: 40px;
  width: 120px;
 height: 50px;
 font-size: 18px;
 font-family: monaco;
 color: #FFF;
 text-decoration: none;
 outline: none;
 letter-spacing: 8px;
 padding-left: 12px;
 border-radius: 5px;
  background-color: #77ceff;
}

</style>
