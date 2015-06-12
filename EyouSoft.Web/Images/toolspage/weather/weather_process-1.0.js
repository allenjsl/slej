/**
 * ������Ϣ����̬��
 * @version 1.0
 */
var WeatherProcesser = {
    //��ʾ�¶�
    getTemperature: function(temperature1,temperature2){
        var res;
		if(temperature1 =='' && temperature2 == ''){
			return '';
		}
        if (temperature1 == temperature2) {
            res = temperature1 + "��";
        }
        else {
            res = temperature1 + "�桫" + temperature2 + "��";
        }
        return res;
    },
    
    //��ʾ����״��
    getStatus: function(status1, status2){
        var res;
		if(status1 == '' && status2 == ''){
			return '';	
		}
        if (status1 == status2) {
            res = status1;
        }
        else {
            res = status1 + "ת" + status2;
        }
        return res;
    },
    
    //������ͼ��
    getBFigure: function(figure1, figure2, status1,status2){
        var res;
		if(figure1 == '' && figure2 == ''){
			return '';	
		}
        if (figure1 == figure2) {
            res = "<img src=http://image2.sina.com.cn/dy/weather/images/figure/" + figure1 + "_big.gif title=" + status1 + ">";
        }
        else {
            res = "<img src=http://image2.sina.com.cn/dy/weather/images/figure/" + figure1 + "_big.gif title=" + status1 + "> - <img src=http://image2.sina.com.cn/dy/weather/images/figure/" + figure2 + "_big.gif title=" + status2 + ">";
        }
        return res;
    },
    
    //������ͼ��
    getMFigure: function(figure1, figure2, status1,status2){
        var res;
		if(figure1 == '' && figure2 == ''){
			return '';	
		}
        if (figure1 == figure2) {
            res = "<img src=http://image2.sina.com.cn/dy/weather/images/figure/" + figure1 + "_mid.gif title=" + status1 + ">";
        }
        else {
            res = "<img src=http://image2.sina.com.cn/dy/weather/images/figure/" + figure1 + "_mid.gif title=" + status1 + "> - <img src=http://image2.sina.com.cn/dy/weather/images/figure/" + figure2 + "_mid.gif title=" + status2 + ">";
        }
        return res;
    },
    
    //����Сͼ��
    getSFigure: function(figure1, figure2, status1,status2){
        var res;
		if(figure1 == '' && figure2 == ''){
			return '';	
		}
		var status = this.getStatus(status1,status2);
        if (figure1 == figure2) {
            res = "<img src=http://image2.sina.com.cn/dy/weather/images/figure/" + figure1 + "_small.gif title=" + status + ">";
        }
        else {
            res = "<img src=http://image2.sina.com.cn/dy/weather/images/figure/" + figure1 + "_small.gif title=" + status + "><img src=http://image2.sina.com.cn/dy/weather/images/figure/" + figure2 + "_small.gif title=" + status + ">";
        }
        return res;
    },
    
    //��ʾ����
    getDate: function(year1, month1, day1, year2, month2, day2){
        var res = year1 + "��" + month1 + "��" + day1 + "��-";
        if (year1 != year2) {
            res += year2 + "��";
        }
        else {
            if (month1 != month2) {
                res += month2 + "��";
            }
        }
        res += day2 + "��";
        return res;
    },
    
    //��ʾ����
    getDirection: function(direction1, direction2){
        var res = "";
        if (direction1 != "" && direction2 != "" && direction1 != direction2) {
            res = direction1 + "ת" + direction2;
        } else if (direction1 != "" && direction2 != "" && direction1 == direction2) {
			res = direction1;
		} else if (direction1 != "" && direction2 == "") {
			res = direction1;
		} else if (direction2 != "" && direction1 == "") {
			res = direction2;
		} else {
			res = "-";
		}
        return res;
    },
    
    //��ʾ����
    getPower: function(power1, power2){
        var res = "";
        if (power1 == power2 && power1 == "") {
            res = "С��3��";
        }
        else 
            if (power1 != "" && power2 == "") {
                res = power1 + "��";
            }
            else 
                if (power2 != "" && power1 == "") {
                    res = power2 + "��";
                }
                else 
                    if (power1 != "" && power2 != "" && power1 != power2) {
                        res = power1 + "�� �� " + power2 + "��";
                    }
                    else 
                        if (power1 != "" && power2 != "" && power1 == power2) {
                            res = power1 + "��";
                        }
        return res;
    },
    
    //��ʾ��������
    getPollution: function(pollution){
        var res = "";
        if (pollution == "") {
            res = "-";
        }
        else 
            if (pollution == 1) {
                res = "��";
            }
            else 
                if (pollution == 2) {
                    res = "��";
                }
                else 
                    if (pollution == 3) {
                        res = "��";
                    }
                    else 
                        if (pollution == 4) {
                            res = "�ϲ�";
                        }
                        else {
                            res = "�ܲ�";
                        }
        return res;
    },
    
    //��ʾ������ǿ��
    getZWX: function(zwx){
        var res = "";
        if (zwx == "") {
            res = "-";
        }
        else 
            if (zwx == 0 || zwx == 1 || zwx == 2) {
                res = "����";
            }
            else 
                if (zwx == 3 || zwx == 4) {
                    res = "��";
                }
                else 
                    if (zwx == 5 || zwx == 6) {
                        res = "�е�";
                    }
                    else 
                        if (zwx == 7 || zwx == 8) {
                            res = "ǿ";
                        }
                        else {
                            res = "��ǿ";
                        }
        return res;
    },
    
    //��ʾ���ʶ�
    getSSD: function(ssd){
        var res;
        if (ssd == "") {
            res = "-";
        }
        else 
            if (ssd == 1) {
                res = "����";
            }
            else 
                if (ssd == 2) {
                    res = "������";
                }
                else 
                    if (ssd == 3) {
                        res = "һ������";
                    }
                    else 
                        if (ssd == 4) {
                            res = "�ϲ�����";
                        }
                        else {
                            res = "������";
                        }
        return res;
    },
    
    //��ʾϴ��״��
    getXCZ: function(){
        var res;
        if (xcz == "") {
            res = "-";
        }
        else 
            if (xcz == 1) {
                res = "����ϴ��";
            }
            else 
                if (xcz == 2) {
                    res = "������ϴ��";
                }
                else 
                    if (xcz == 3) {
                        res = "�ϲ�����ϴ��";
                    }
                    else {
                        res = "����ϴ��";
                    }
        return res;
    }
};



