<template>
  <div>
    <h3>{{msg}}</h3>
  </div>
</template>
<script>
export default {
  data(){
    return {
      msg:'',
      type:''
    }
  },
  created() {
    this.type = this.$route.query.type;
    this.msg={'add':'添加成功，两秒后跳转......',
              'revice':'修改成功，两秒后跳转......',
              'remove':'删除成功，两秒后跳转......'}[this.type];
  },
  mounted() {
    const t = this
    setTimeout(function () {
      t.$router.push({
        path: '/'
      })
    },2000)
  }
}
</script>
<style lang="css" scoped>
</style>
