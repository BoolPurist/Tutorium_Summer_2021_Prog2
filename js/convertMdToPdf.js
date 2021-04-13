
const fs = require('fs/promises');
const path = require('path');
const  { mdToPdf }  = require('md-to-pdf');

const excludedFiles = [ "README.md" ];
const npmLocation = path.resolve('./');
const outputPath = path.join(npmLocation, 'pdf');
const cwd = path.dirname(process.argv[1]);

(async() => {

    console.log("Reading all md files");
    let allMdFiles = await fs.readdir(npmLocation);
    allMdFiles = allMdFiles.filter(element => path.extname(element) === ".md");
    allMdFiles = allMdFiles.filter(element => {
        
        for (const excludedFile of excludedFiles) {
            if (excludedFile === element) {
                return false;
            }
        }

        return true;
    });

    console.log("Creating pdf from md files");
    
    allMdFiles.forEach(async mdFile => {

        const pathToPdf = path.join(outputPath, mdFile.replace(".md", ".pdf"));
        const pathToMd = path.join(npmLocation, mdFile);
        console.log(`Creating ${pathToPdf} from ${pathToMd}`);
        const pdfFile = await mdToPdf({path: mdFile});
        await fs.writeFile(pathToPdf, pdfFile.content);
    });
})();