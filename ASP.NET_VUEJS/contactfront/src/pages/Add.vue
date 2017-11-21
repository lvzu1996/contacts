<template>
  <div >
    
    <div class="add-top">
      <h1>新增联系人</h1>
    </div>
    <form action="App/addContact" method="post" name="contact" id="contact-form">
      <div>name:</div><input v-model="form.name" @blur="_validate(form.name,'name')" type="text" name="name" ><br>
      <div>gender:</div><input v-model="form.gender" type="text" name="gender" ><br>
      <div>company:</div><input v-model="form.company" type="text" name="company"><br>
      <div>phone:</div><input v-model="form.phonenumber" @blur="_validate(form.phonenumber,'phone')" maxlength="11" type="text" name="phonenumber" ><br>
      <input type="button" value="提交" @click="_toAdd">
      <input type="button" name="backbtn" value="返回" @click="_toQuery">
    </form>

  </div>
</template>
<script>
import lvValidate from '../utils/lvValidate'

export default {
  data(){
    return {
      host:'http://localhost:52177',
      form:{
        name:'',
        gender:'',
        company:'',
        phonenumber:'',
      },
    }
  },
  mounted() {
    //do something after mounting vue instance
  },
  methods: {
    _toQuery() {
      this.$router.push({
        path: '/'
      })
    },
    _toAdd(){
      const t = this
      if(!lvValidate.inputValidate(t.form.name,'name')){
        t.$message.error('姓名不能为空！');
        return
      }
      if(!lvValidate.inputValidate(t.form.phonenumber,'phone')){
        t.$message.error('手机号输入有误！');
        return
      }
      fetch(`http://localhost:52177/App/AddContact`,{
        method:'post',
        body: `id=1&name=${t.form.name}&gender=${t.form.gender}&company=${t.form.company}&phonenumber=${t.form.phonenumber}`,
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/x-www-form-urlencoded"
        },
      })
      .then(res => res.json())
      .then(res => {
        if(res.msg == "success"){
          this.$router.push({
            path: '/success?type=add'
          })
        }
        else {
          this.$router.push({
            path: '/fail?type=add'
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
    
  }
  
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
  margin-top: 30px;
  margin-left: 70px;
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
