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
    this.msg={'add':'添加失败，两秒后跳转......',
              'revice':'修改失败，两秒后跳转......',
              'remove':'删除失败，两秒后跳转......',
              'usedpn':'此号码已经使用了！'}[this.type];
  },
  mounted() {
    const t = this
    setTimeout(function () {
      t.$router.push({
        path: '/'
      })
    },4000)
  }
}
</script>
<style lang="css" scoped>
</style>
