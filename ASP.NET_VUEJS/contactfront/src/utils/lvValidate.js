const telRegExp = new RegExp(/^1(3|4|5|7|8)\d{9}$/)

function inputValidate(value,type) {
  if(type == 'name'){
    if(!value){
      return false
    }
    return true
  }
  else if (type == 'phone') {
    return telRegExp.test(value)
  }
}

var lvValidate = {
  inputValidate:inputValidate
}

export default lvValidate
