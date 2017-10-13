<template lang="html">
<div>
  <div class="query-top">
    <h1>联系人列表</h1>
    <input type="button" name="addbtn" value="新增联系人" @click="_toAdd">
  </div>
  <div class="query-contactList">
  
      <div class="query-contact" v-for="item in contactList" :key="item.key">
        <div class="query-infos">
          <img src="http://lvzu-imgs.oss-cn-hangzhou.aliyuncs.com/%E4%B8%8B%E8%BD%BD.png" alt="none">
          <span>{{item.name}}</span>
          <span>{{item.phonenum1}}</span>
          <span>{{item.phonenum2}}</span>
          <span>{{item.address}}</span>
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
export default {
  data(){
    return {
      host:'http://localhost:52177/App',
      contactList:[],
    }
  },
  
  mounted() {
      fetch(`${this.host}/QueryContact`)
      .then(re => re.json())
      .then(re =>{
        this.contactList = re
      })
      // this.contactList = [
      //   {id:1,name:2,avatar:3,phonenum1:1,phonenum2:2,address:3},
      //   {id:1,name:2,avatar:3,phonenum1:1,phonenum2:2,address:3},
      //   {id:1,name:2,avatar:3,phonenum1:1,phonenum2:2,address:3},
      //   {id:1,name:2,avatar:3,phonenum1:1,phonenum2:2,address:3},
      //   {id:1,name:2,avatar:3,phonenum1:1,phonenum2:2,address:3}]
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
      fetch(`${this.host}/RemoveContact?id=${id}`)
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
    }
  },


}
</script>

<style lang="css">
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

</style>
