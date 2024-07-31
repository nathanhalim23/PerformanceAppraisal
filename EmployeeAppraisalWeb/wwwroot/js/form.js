(() => {

    let number = 1;
    let dataTable = [];
    let selectedRadioValues = [];

    let numberOneTd = document.querySelector('#number-one');
    let strategicObjectiveTd = document.querySelector('.str-obj-input-class');
    let kpiIdTd = document.querySelector('.kpi-drop-class');
    let unitOfMeasurementTd = document.querySelector('.uom-input-class');
    let polarizationIdTd = document.querySelector('.polar-drop-class');
    let actualTd = document.querySelector('.aktual-input-class');

    numberOneTd.textContent = number;
    strategicObjectiveTd.setAttribute('id', `str-obj-input${number}`);
    kpiIdTd.setAttribute('id', `kpi-drop${number}`);
    unitOfMeasurementTd.setAttribute('id', `uom-input${number}`);
    polarizationIdTd.setAttribute('id', `polar-drop${number}`);
    actualTd.setAttribute('id', `aktual-input${number}`);

    function sumBobot(tableId, columnIndex) {
        const indicatorTable = document.getElementById(tableId);

        let sum = 0;

        for (let i = 2; i < indicatorTable.rows.length-1; i++) {
            const row = indicatorTable.rows[i];
            const cell = row.cells[columnIndex];
            const bobot = cell.querySelector('input');

            if(bobot){
                const bobotValue = parseInt(bobot.value);

                if(!isNaN(bobotValue)) {
                    sum += bobotValue;
                }
            }
        }

        return sum;
    }

    function setNilaiUnjukKerja() {
        const indicatorTable = document.getElementById('indikator-utama-kerja');

        for (let i = 2; i < indicatorTable.rows.length-1; i++) {
            const row = indicatorTable.rows[i];

            const bobot = row.cells[4];
            const bobotCell = bobot.querySelector('#bobot');

            const tingkatUnjukKerja = row.cells[8];

            const target = row.cells[6];
            const targetCell = target.querySelector('input')

            const actual = row.cells[7];
            const actualCell = actual.querySelector('input');

            const resultCell = row.cells[9];

            bobotCell.addEventListener(
                'input',
                function () {
                    bobotCell.setAttribute('value', bobotCell.value);
                }
            );

            targetCell.addEventListener(
                'input',
                function () {
                    targetCell.setAttribute('value', targetCell.value);
                }
            );

            actualCell.addEventListener(
                'input',
                function () {
                    actualCell.setAttribute('value', actualCell.value);
                    const actualCalculcation = parseInt(actualCell.value) / parseInt(targetCell.value) * 100;

                    if (actualCalculcation > 130) {
                        tingkatUnjukKerja.innerText = 5
                    }
                    else if (actualCalculcation <= 130 && actualCalculcation >= 110) {
                        tingkatUnjukKerja.innerText = 4
                    }
                    else if (actualCalculcation <= 109 && actualCalculcation >= 91) {
                        tingkatUnjukKerja.innerText = 3
                    }
                    else if (actualCalculcation <= 90 && actualCalculcation >= 71) {
                        tingkatUnjukKerja.innerText = 2
                    }
                    else {
                        tingkatUnjukKerja.innerText = 1
                    }

                    const nilaiUnjukKerja = parseInt(bobotCell.value) * parseInt(tingkatUnjukKerja.textContent);
                    resultCell.innerText = nilaiUnjukKerja;

                    
                }
            );

            
        }
    }


    function kompetensiDasarInsertValues() {
        const radioRow1 = document.getElementsByName('row1');
        const radioRow2 = document.getElementsByName('row2');
        const radioRow3 = document.getElementsByName('row3');
        const radioRow4 = document.getElementsByName('row4');
        const radioRow5 = document.getElementsByName('row5');

        let customerFocus;
        let integritas;
        let kerjasamaTim;
        let continuousImprovement;
        let workExcellence;

        for (let i = 0; i < radioRow1.length; i++) {
            if (radioRow1[i].checked) {
                customerFocus = parseInt(radioRow1[i].value);
            }
        }

        for (let i = 0; i < radioRow2.length; i++) {
            if (radioRow2[i].checked) {
                integritas = parseInt(radioRow2[i].value);
            }
        }

        for (let i = 0; i < radioRow3.length; i++) {
            if (radioRow3[i].checked) {
                kerjasamaTim = parseInt(radioRow3[i].value);
            }
        }

        for (let i = 0; i < radioRow4.length; i++) {
            if (radioRow4[i].checked) {
                continuousImprovement = parseInt(radioRow4[i].value);
            }
        }

        for (let i = 0; i < radioRow5.length; i++) {
            if (radioRow5[i].checked) {
                workExcellence = parseInt(radioRow5[i].value);
            }
        }

        

    }
    
   
    let addRowBtn = document.querySelector('#add-row-btn');
    addRowBtn.addEventListener(
        'click',
        function () {

            ++number;
            
            let tableTbody = document.querySelector('#indikator-utama-kerja tbody');

            var newTr = document.createElement('tr');
            newTr.innerHTML =
            `
                <td>${number}</td>
                <td>
                    <input type="text" id="str-obj-input${number}"/>
                </td>
                <td>
                    <select id="kpi-drop${number}">
                        
                    </select>
                </td>
                <td>
                    <input type="text" id="uom-input${number}"/>
                </td>
                <td>
                    <input type="number" id="bobot"/>
                </td>
                <td>
                    <select id="polar-drop${number}">
                        
                    </select>
                </td>
                <td>
                    <input type="number"/>
                </td>
                <td>
                    <input type="number"/>
                </td>
                <td></td>
                <td></td>
            `;
            
            tableTbody.appendChild(newTr);

            let kpiDrop = document.querySelector('.kpi-drop-class');

            for (let i = 0; i < kpiDrop.options.length; i++) {
                var kpiOptions = kpiDrop.options[i];

                let otherKpiDrop = document.querySelector(`#kpi-drop${number}`);
                let newKpiOptions = document.createElement('option');
                
                newKpiOptions.text = kpiOptions.text;
                newKpiOptions.value = kpiOptions.value;

                otherKpiDrop.appendChild(newKpiOptions);
            }


            let polarDrop = document.querySelector('.polar-drop-class');

            for (let j = 0; j < polarDrop.options.length; j++) {
                var polarOptions = polarDrop.options[j];

                let otherPolarDrop = document.querySelector(`#polar-drop${number}`);
                let newPolarOptions = document.createElement('option');

                newPolarOptions.text = polarOptions.text;
                newPolarOptions.value = polarOptions.value;

                otherPolarDrop.appendChild(newPolarOptions);
            }

            setNilaiUnjukKerja();
        }
    );

    

        /* Form */
    let formSubmitBtn = document.querySelector('#submit-form-btn');
    formSubmitBtn.addEventListener(
        'click',
        function () {

            const totalBobot = sumBobot('indikator-utama-kerja', 4);

            if (totalBobot != 100) {
                alert('Total Bobot harus 100%!');
            }
            else {

                const nikValue = document.querySelector('#nik-value').textContent;

                formInsertAPI();

                let getFormAPI = (nik) => {
                    const getFormUrl = `http://localhost:8081/api/v1/appraisalForm/${nik}`;

                    let request = new XMLHttpRequest();
                    request.open('GET', getFormUrl);
                    request.send();
                    request.onload = () => {
                        const res = request.response;
                        const formJSON = JSON.parse(res);


                        let performanceIndicatorInsertValue = () => {
                            const nikValue = document.querySelector('#nik-value').textContent;

                            const table = document.querySelector('#indikator-utama-kerja');
                            const rows = table.querySelectorAll('tr');


                            rows.forEach((row, index) => {
                                if (index === 0) return;

                                const td = row.querySelectorAll('td');
                                const rowData = {
                                    id: 0,
                                    nik: nikValue,
                                    strategicObjective: td[1].querySelector('input').value,
                                    kpiId: parseInt(td[2].querySelector('select').value),
                                    unitOfMeasurement: td[3].querySelector('input').value,
                                    polarizationId: parseInt(td[5].querySelector('select').value),
                                    actual: parseInt(td[7].querySelector('input').value),
                                    formId: formJSON.id
                                };

                                dataTable.push(rowData);
                            });


                            return {
                                'id': dataTable[0].id,
                                'nik': dataTable[0].nik,
                                'strategicObjective': dataTable[0].strategicObjective,
                                'kpiId': dataTable[0].kpiId,
                                'unitOfMeasurement': dataTable[0].unitOfMeasurement,
                                'polarizationId': dataTable[0].polarizationId,
                                'actual': dataTable[0].actual,
                                'formId': formJSON.id
                            }

                        }

                        let performanceIndicatorInsertAPI = () => {
                            const performanceIndicatorInsertUrl = 'http://localhost:8081/api/v1/performanceIndicator/Insert';

                            let request = new XMLHttpRequest();
                            request.open('POST', performanceIndicatorInsertUrl);
                            request.setRequestHeader('Content-Type', 'application/json');
                            request.send(JSON.stringify(performanceIndicatorInsertValue()));
                            request.onload = () => {
                                console.log(request.response);
                            }
                        }

                        performanceIndicatorInsertAPI();

                    }
                }

                setTimeout(
                    function () {
                        getFormAPI(nikValue);
                    },
                    500
                );


            }

        }
    );

    let formInsertValue = () => {
        const formId = 0;
        const nikValue = document.querySelector('#nik-value').textContent;
        const periodeValue = document.querySelector('#periode-value').value;

        return {
            'id': formId,
            'nik': nikValue,
            'periode': parseInt(periodeValue)
        }
    }

    let formInsertAPI = () => {
        const formInsertUrl = 'http://localhost:8081/api/v1/appraisalForm/insert';

        let request = new XMLHttpRequest();
        request.open('POST', formInsertUrl);
        request.setRequestHeader('Content-Type', 'application/json');
        request.send(JSON.stringify(formInsertValue()));
        request.onload = () => {
            /*location.reload();*/
        }
    }


    setNilaiUnjukKerja();
    getRadioValuesKompetensiDasar();

})()