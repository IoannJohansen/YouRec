import { TagCloud } from 'react-tagcloud';
import './TagsCloud.css';

const data = [
    { value: 'JavaScript', count: 38 },
    { value: 'React', count: 30 },
    { value: 'Nodejs', count: 28 },
    { value: 'Express.js', count: 25 },
    { value: 'HTML5', count: 33 },
    { value: 'MongoDB', count: 18 },
    { value: 'CSS3', count: 20 },
    { value: 'JavaScript', count: 38 },
    { value: 'React', count: 30 }
]

const options = {
    luminosity: 'light',
    hue: 'blue'
}

export default function TagsCloud() {
    return (
        <div className="container">
            <p bg="primary" className="text-center h3">Available tags</p>
            <TagCloud
                className="TagCloud col-sm-4"
                minSize={12}
                maxSize={35}
                colorOptions={options}
                tags={data}
                onClick={tag => alert(`'${tag.value}' was selected!`)}
            />
        </div>
    );
}