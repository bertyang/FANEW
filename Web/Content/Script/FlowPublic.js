
function submitForm() {

    $('#form').form('submit', {
        onSubmit: function () {

            //表单验证
            if (validDataBeforeSubmit() && $(this).form('validate')) {
                parent.DisableButton();
                return true;
            }
            else {
                return false;
            }
        },
        success: function (msg) {

            var data = eval('(' + msg + ')');

            if (data.IsSuccess) {
                
                //选下一步骤
                if (data.SplitType == "or_split") {
                    parent.OrSplit(data.ActivtyInstId);
                }
                else {
                    parent.AndSplit(data.ActivtyInstId);
                }
            }
            else {
                $.messager.alert('提示', data.Message, 'info', function () {
                });

            }
        },
        error: function () {
            $.messager.alert('错误', '提交失败！', "error");
        }
    });

}


function approveFormYes_Locale() {

    $('#form').form('submit', {
        onSubmit: function () {
            if (validBeforeApproveFormYes() && $(this).form('validate')) {
                parent.DisableButton();
                return true;
            }
            else {
                return false;
            }
        },
        success: function (msg) {

            var data = eval('(' + msg + ')');

            if (data.IsSuccess) {
                parent.approveFormYes_Common();
            }
            else {
                $.messager.alert('提示', data.Message, 'info', function () {
                });
            }

        },
        error: function () {
            $.messager.alert('错误', '签核失败！', "error");
        }
    });
}


function approveFormNo_Locale() {

    $('#form').form('submit', {
        onSubmit: function () {
            if (validBeforeApproveFormNo()) {
                parent.DisableButton();
                return true;
            }
            else {
                return false;
            }
        },
        success: function (msg) {

            var data = eval('(' + msg + ')');

            if (data.IsSuccess) {
                parent.approveFormNo_Common();
            }
            else {
                $.messager.alert('提示', data.Message, 'info', function () {
                });
            }
        },
        error: function () {
            $.messager.alert('错误', '签核失败！', "error");
        }
    });
}